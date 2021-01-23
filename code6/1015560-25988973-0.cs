    public class YourEdmxClassViewModel : ViewModel
    {
        private YourEdmxClass model;
        public YourEdmxClassViewModel(YourEdmxClass model)
        {
            this.model = model;
        }
        public int SomeProperty
        {
            get { return this.model.SomeProperty; }
            set
            {
                this.model.SomeProperty = value;
                this.RaisePropertyChanged(() => this.SomeProperty);
            }
        }
    }
