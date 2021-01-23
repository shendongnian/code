    public ClassA
    {
        private ClassB classBInstance;
        public ClassA(ClassB classBInstance)
        {
            this.classBInstance = classBInstance;
        }
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
