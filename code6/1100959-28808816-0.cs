    public class AddItemViewModel
    {
        private IEventAggregator _eventAggregator;
        public AddItemViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AddItemEvent>().Subscribe(AddItem);
        }
        private void AddItem(AddItemPayload payload)
        {
            // Your logic here
        }
    }
