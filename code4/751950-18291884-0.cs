    class DictionaryActivator
    {
        Dictionary<string, Type> Dictionary = new Dictionary<string, Type>();
        public DictionaryActivator()
        {
            Dictionary.Add("MyCar", typeof(Car));
            Dictionary.Add("MyHouse", typeof(House));
            Dictionary.Add("MyFruit", typeof(Fruit));
        }
        public T GetInstance<T>(string type)
        {
            return (T)Activator.CreateInstance(Dictionary[type]);
        }
    }
