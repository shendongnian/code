    partial class MyDataContext
    {
        [Function(Name = "ISNUMERIC", IsComposable = true)]
        public int IsNumeric(string input)
        {
            throw new NotImplementedException(); // this won't get called
        }
    }
