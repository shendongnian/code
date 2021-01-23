    public class BarChooserAttribute : Attribute
    {
        public BarChooserAttribute(BarTypeEnum barType) { BarType = barType; }
        public BarTypeEnum BarType { get; set; }
    }
    public static class CreateBarMethods
    {
        [BarChooser(BarTypeEnum.TypeA)]
        public static Bar CreateTypeA(Foo foo)
        {
            return new Bar { Message = "A" };
        }
        [BarChooser(BarTypeEnum.TypeB)]
        public static Bar CreateTypeB(Foo foo)
        {
            return new Bar { Message = "B" };
        }
    }
    public static Bar CreateBar(Foo foo, BarTypeEnum barType)
    {
        var methodWrapper = typeof(CreateBarMethods).GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Select(m => new { Method = m, Att = (BarChooserAttribute)m.GetCustomAttributes(typeof(BarChooserAttribute), false).Single() })
            .Single(x => x.Att.BarType == barType);
        return (Bar)methodWrapper.Method.Invoke(null, new[] { foo });
    }
