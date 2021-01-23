    public class OrderProcessingViewModel
    {
        public DelegateCommand<KeyEventArgs> ProcessOrderCommand;
        private string targetProperty;
        public OrderProcessingViewModel()
        {
            ProcessOrderCommand = new DelegateCommand<KeyEventArgs>(ProcessOrder, CanProcessOrder);
        }
        private Order OrderToProcess { get; set; }
        public string TargetProperty
        {
            get { return targetProperty; }
            set
            {
                if (!Equals(targetProperty, value))
                {
                    targetProperty = value;
                    OnPropertyChanged("TargetProperty");
                    //IMPORTANT: Let the delegate command to call its CanExecute method so we can update the Enabled property.
                    ProcessOrderCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private bool CanProcessOrder(KeyEventArgs arg)
        {
            //TODO: Here you check when to enable or disable the check box
            var mustEnable = OrderToProcess != null;
            //The value returned from this method is the result assigned to the IsEnable property for the command's related object
            return mustEnable;
        }
        private void ProcessOrder(KeyEventArgs obj)
        {
            //Do the stuff to process the order
        }
    }
