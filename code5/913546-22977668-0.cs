    public class OptionViewModel
    {
       public string SelectedValue { get; set; }
       public List<string> Values { get; set; }
       public static OptionViewModel Create<TEnum>() where TEnum : struct, IConvertible
       {
            var ovm = new OptionViewModel();
            foreach (var value in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
            {
                 ovm.Values.Add(value);
            }
            return ovm;
       }
    }
