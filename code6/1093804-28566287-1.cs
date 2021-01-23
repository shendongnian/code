    public class Tests
    {
        public void Test()
        {
            IMyVector<Base> baseVector= null;
            IMyVector<Derived> derivedVector= null;
            baseVector.AddVector(derivedVector);
        }
    }
