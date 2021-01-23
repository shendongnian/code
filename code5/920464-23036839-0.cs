        // seen by the developer in the source code
        Process();
        …
        void Process(Foo arg = new Foo())
        {
            … 
        }
        // actually done by the compiler
        Process_Thunk();
        …
        void Process_Thunk()
        {
            Process(new Foo());
        }
        void Process()
        {
            … 
        }
