    class DictionaryActivator
    {
        Dictionary<string, Type> Dictionary = new Dictionary<string, Type>();
        public DictionaryActivator()
        {
            Dictionary.Add("MyCar", typeof(Car));
            Dictionary.Add("MyHouse", typeof(House));
            Dictionary.Add("MyFruit", typeof(Fruit));
            Dictionary.Add("MyComputer", typeof(Computer));
        }
        public T GetInstance<T>(string type, params object[] parameters)
        {
            if (parameters.Count() == 0)
            {
                return (T)Activator.CreateInstance(Dictionary[type]);
            }
            else
            {
                return (T)Activator.CreateInstance(Dictionary[type], parameters.ToArray());
            }
        }
    }
