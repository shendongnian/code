    class PrintDecorator : A
    {
        private A wrappedA;
        public PrintDecorator(A a)
        {
            wrappedA = a;
        }
        public virtual void Print()
        {
            //wrap the derived logic with the pre- and post- processing
            StartingProcedure();
            wrappedA.Print();
            EndingProcedure();
        }
    }
    class A
    {
        public virtual void Print()
        { 
        }
        protected void StartingProcedure()
        {
            /// something 
        }
        protected void EndingProcedure()
        {
            /// something 
        }
    }
    class A_1 : A
    {
        public override void Print()
        {
            /// class specific print operation
        }
    }
    class A_2 : A
    {
        public override void Print()
        {
            /// class specific print operation
        }
    }
