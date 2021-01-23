    interface IProcessorUser<out T> where T : ProcessorBase
    {
        void ReceiveCommand();
    }
    class ProcessorUser<T> : IProcessorUser<T> where T : ProcessorBase
    {
        public void ReceiveCommand()
        {
            Activator.CreateInstance(typeof(T), this);
        }
    }
    abstract class ProcessorBase
    {
        protected ProcessorBase(IProcessorUser<ProcessorBase> param)
        {
        }
    }
    class SpecialProcessor : ProcessorBase
    {
        private IProcessorUser<SpecialProcessor> _param;
        public SpecialProcessor(IProcessorUser<SpecialProcessor> param)
            : base(param)
        {
            _param = param;
        }
        public void ReceiveCommand() { _param.ReceiveCommand(); }
    }
