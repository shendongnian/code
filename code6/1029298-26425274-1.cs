    public enum Option
    {
        OptionOne = 1,
        OptionTwo = 2
    }
    public static string GetOptionDisplayName(Option option)
    {
        switch (option)
        {
            case Option.OptionOne:
                return string.Format("{0} - {1}", "Option One", MyClass.MyProperty);
            case Option.OptionTwo:
                return string.Format("{0} - {1}", "Option Two", MyClass.MyProperty);
            default:
                return option.ToString();
        }
    }
    public class AnotherOption
    {
        public Option Option { get; set; }
        public string DisplayName
        {
            get { return GetOptionDisplayName(this.Option); }
        }
    }
