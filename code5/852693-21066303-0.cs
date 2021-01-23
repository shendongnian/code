    public class MyException : Exception
    {
        public string MyField { get; private set; }
        public MyException(string myField)
        {
            this.MyField = myField;
        }
    }
