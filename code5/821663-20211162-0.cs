    public abstract class ViewModelBase
    {
        public ViewModelBase(Dispatcher dispatcher)
        {
            UIDispatcher = dispatcher;
        }
        protected Dispatcher UIDispatcher;
    }
