    class A { }
    class B { }
    class WorkerA
    {
        public WorkerA(Action<A> doA) { }
    }
    class WorkerAorB
    {
        public WorkerAorB(Action<A> doA) { }
        public WorkerAorB(Action<B> doB) { }
    }
    class WorkerAandB
    {
        public WorkerAandB(Action<A> doA, Action<B> doB = null) { }
        public WorkerAandB(Action<B> doB) { }
    }
    class ManagerA
    {
        void DoA(A a) { }
        static void DoAstatic(A a) { }
        Action<A> DoAfunc = DoAstatic;
        ManagerA()
        {
            new WorkerA((A a) => { }); // ok
            new WorkerA(DoA); // ok
            new WorkerA(DoAstatic); // ok
            new WorkerAorB((A a) => { }); // ok
            new WorkerAorB((B b) => { }); // ok
            new WorkerAorB(DoA); // ok
            new WorkerAorB(DoAstatic); // ok
            new WorkerAorB(a => { }); // ok
            new WorkerAorB(DoAfunc); // ok
            new WorkerAandB(a => { }); // ok
            new WorkerAandB(DoA); // ok
            new WorkerAandB(DoAstatic); // ok
            new WorkerAandB(DoA, null); // ok
            new WorkerAandB(DoAstatic, null); // ok
            new WorkerAandB(DoAfunc); // ok
        }
    }
