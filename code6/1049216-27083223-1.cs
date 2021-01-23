    public class DictionaryClass<T>
    {
        private readonly Dictionary<string, MyClass<T>> dict;
        public DictionaryClass()
        {
            dict = new Dictionary<string, MyClass<T>>();
        }
        public MyClass<T> this[string index]
        {
            get
            {
                return dict[index];
            }
            set
            {
                dict[index] = value;
            }
        }
    }
