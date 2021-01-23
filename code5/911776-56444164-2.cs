    public class MyVm : ViewModelBase
    {
        [DisplayName("Number")]
        [Description("Provide a number")]
        public int OrdinaaryOrdinal {get; set;}
        [DisplayName("Compare operator")]
        [Description("to do")]
        public ComparisonOperators Operator {get; set;}
        ...
