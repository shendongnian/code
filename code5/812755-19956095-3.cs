    /// Template Method
    protected void Run()
    {
        StartingProcedure();
        Print();
        EndingProcedure();
    }
    class A_1 : A
    {
        public override void Print()
        {
            /// class specific print operation
        }
        public A_1()
        {
           base.Run();
        }
    }
