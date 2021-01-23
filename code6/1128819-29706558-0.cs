        public ManagerA()
        {
            new WorkerA(() => new A()); // ok
            new WorkerA(GetA); // ok
            new WorkerA(GetAstatic); // ok
            new WorkerAorB(() => new A()); // ok
            new WorkerAorB(() => new B()); // ok
            new WorkerAorB((Func<A>)GetA); // cast to avoid error CS0121
            new WorkerAorB((Func<A>)GetAstatic); // cast to avoid error CS0121
            new WorkerAorB(() => GetA()); // ok
            new WorkerAorB(GetAfunc); // ok
            new WorkerAandB(() => new A()); // ok
            new WorkerAandB((Func<A>)GetA); // cast to avoid error CS0407
            new WorkerAandB((Func<A>)GetAstatic); // cast to avoid error CS0407
            new WorkerAandB(GetA, null); // ok
            new WorkerAandB(GetAstatic, null); // ok
            new WorkerAandB(GetAfunc); // ok
        }
