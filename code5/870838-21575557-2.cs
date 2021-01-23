    public ClassA
    {
        private ClassB classBInstance;
        void buttonClick(...)
        {
            classBInstance.SomeFunction(someVariable);
        }
    }
    public ClassB
    {
        void SomeFunction(paramater)
        {
            mySecretVariable = parameter;
            CallAnotherMethodThatUsesThisVariable();
        }
    }
