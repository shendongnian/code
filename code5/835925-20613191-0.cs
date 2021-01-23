    public abstract class TestFactory
    {
        //static method that can create concrete factories
        public static TestFactory CreateTestFactory(FactoryType factoryType)
        {
            if (!Enum.IsDefined(typeof(FactoryType), factoryType)
            {
                 throw InvalidEnumArgumentException(...);
            }
            TestFactory factory = null;
            switch (factoryType)
            {
                case FactoryType.Blood:
                    factory = new BloodTestFactory();
                    break;
                case FactoryType.Urine:
                    factory = new UrineTestFactory();
                    break;
                default:
                    break;
            }
            return factory;
        }       
        //...
    }
