    interface IXyzStepWork
    {
        void DoXyz();
    }
    interface IAbcStepWork
    {
        void DoAbc();
    }
    interface IAbcXyzWork : IAbcStepWork, IXyzStepWork
    {
    }
    class AbcStep
    {
        private readonly IAbcStepWork work;
        public AbcStep(IAbcStepWork work)
        {
            this.work = work;
        }
        public void Execute()
        {
            work.DoAbc();
        }
    }
    class AbcXyzStep
    {
        private readonly IAbcXyzWork work;
        public AbcXyzStep(IAbcXyzWork work)
        {
            this.work = work;
        }
        public void Execute()
        {
            work.DoAbc();
            work.DoXyz();
        }
    }
