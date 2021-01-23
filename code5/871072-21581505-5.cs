    public class Class1 
    {
        public void CallStaticConstructorHere()
        {
            RuntimeHelpers.RunClassConstructor(typeof(Test).TypeHandle);
        }
    }
