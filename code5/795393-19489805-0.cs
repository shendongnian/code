    using System;
    using System.Collections;
    
    interface IJonDictionary : IEnumerable
    {
        new IJonDictionaryEnumerator GetEnumerator();
    }
    
    interface IJonDictionaryEnumerator : IEnumerator
    {
        new DictionaryEntry Current { get; }
    }
    
    class JonDictionary : IJonDictionary
    {
        private readonly IDictionary dictionary = new Hashtable();
        
        public object this[object key]
        {
            get { return dictionary[key]; } 
            set { dictionary[key] = value; }
        }
        
        public void Add(object key, object value)
        {
            dictionary.Add(key, value);
        }
        
        public IJonDictionaryEnumerator GetEnumerator()
        {
            return new JonEnumerator(dictionary.GetEnumerator());
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        private class JonEnumerator : IJonDictionaryEnumerator
        {
            private readonly IDictionaryEnumerator enumerator;
            
            internal JonEnumerator(IDictionaryEnumerator enumerator)
            {
                this.enumerator = enumerator;
            }
            
            public DictionaryEntry Current
            {
                get { return enumerator.Entry; }
            }
            
            object IEnumerator.Current { get { return Current; } }
            
            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }
            
            public void Reset()
            {
                enumerator.Reset();
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new JonDictionary { 
                { "x", "foo" },
                { "y", "bar" }
            };
            
            foreach (var entry in dictionary)
            {
                Console.WriteLine("{0} = {1}", entry.Key, entry.Value);
            }
        }
    }
