    public class MyComparer : IComparer<object>
    {
        public int MyArgument {get; set;}
        public int Compare(object x, object y)
        {
           // code will then return 1,-1 or 0
           // use MyArgument within the method       
        }
