    public class MyException : ArgumentException
    {
        public MyException(string s) : base(s)
        {
        }
        public int MyValue { set; get; }
    }
