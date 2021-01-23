    public class ChildViewModel : ViewModelBase
    {
        public ChildViewModel()
        {
            this.MessengerInstance.Register<ParentToChildMessage>(this, this.OnParentToChildMessage);
        }
        
        private void OnParentToChildMessage(ParentToChildMessage obj)
        {
            // Inspect obj to decide what to do - let's just set as visible
            this.IsVisible = true;
        }
        public bool IsVisible
        {
            get
            {
                return _IsVisible;
            }
            set
            {
                if (value != _IsVisible)
                {
                    _IsVisible = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool _IsVisible;
    }
