    public class MyIndexedClass
    {
        private string[] _values = new string[]
        {
            "hello",
            "hi",
            "good morning",
            "long time no see"
        };
        public string this[int index]
        {
            get
            {
                Console.WriteLine("Index called with argument value " + index);
                return _values[index];
            }
            set
            {
                Console.WriteLine("Index called with argument value " + index + " and value " + value );
                _values[index] = value;
            }
        }
    }
