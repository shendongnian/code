    public enum KeySignatures
    {
        C,
        G,
        D,
        [EnumDescription("F#")]
        FCress,
        [EnumDescription("C#")]
        CCress,
        //...
    }
    public class EnumDescription : Attribute
    {
        public string Description { get; private set; }
        public EnumDescription(string description)
        {
            Description = description;
        }
    }
    public static class Util
    {
        public static string Description(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    EnumDescription attr =
                        Attribute.GetCustomAttribute(field,
                            typeof(EnumDescription)) as EnumDescription;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return value.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0} desc {1}", KeySignatures.C, KeySignatures.C.Description());
            Console.WriteLine("{0} desc {1}", KeySignatures.CCress, KeySignatures.CCress.Description());
            Console.WriteLine("{0} desc {1}", KeySignatures.FCress, KeySignatures.FCress.Description());
        }
    }
}
