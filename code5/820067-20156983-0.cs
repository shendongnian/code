    public class DerivedAsset : Asset { }
 
    public class Test
    {
        public Manager<Asset> Manager;
        public Test()
        {
            Manager = new Manager<DerivedAsset >();     // compile-time error
        }
    }
