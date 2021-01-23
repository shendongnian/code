    public class TaskbarViewModel : PropertyChangedBase, ITaskbar {
        private readonly IEventAggregator _eventAggregator;
        public TaskbarViewModel(IEventAggregator eventAggregator) {
            _eventAggregator = eventAggregator;
        }
        public void Show() {
            IsVisible = true;
            _eventAggregator.PublishOnUIThread("Your balloontip message");
        }
   
        /// Rest of the implementation
    }
