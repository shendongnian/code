    public class MyBaseClass
    {
        public virtual void Map<T>(T obj)
        {
            // Override in specific class
            //Use PropertyInfo to map the properties of the class
        }
    }
    public class MyFirstClass : MyBaseClass
    {
    }
    public class MySecondClass : MyBaseClass
    {
    }
    public class MyClassFactory
    {
        public T CreateMyClass<T>() where T : MyBaseClass, new()
        {
            return new T();
        }
        public List<T1> MapClass<T1, T2>(List<T2> inputList) where T1 : MyBaseClass, new()
        {
            List<T1> outputList = new List<T1>();
            foreach (T2 input in inputList)
            {
                T1 output = CreateMyClass<T1>();
                output.Map(input);
                outputList.Add(output);
            }
            return outputList;
        }
    }
