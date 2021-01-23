    public class ParentViewModel
    {
        private ChildViewModel _child;
        public ParentViewModel(ChildViewModel child)
        {
            _child = child;
        }
    }
    public class ChildViewModel
    {
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;
 
        public ChildViewModel(IWindowManager windowManager, IEventAggregator eventAggregator) 
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
        }
    }
