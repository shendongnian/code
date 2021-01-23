    public class GenericTest<T> where T : MyBuilder
    {
        [TestInitialize]
        public void Init()
        {
            target = (T)Activator.CreateInstance(typeof(T), new object[] { param1, param2, param3, param4 });
        }
    }
