    public class VehicleViewModel:ViewModelBase
        {
            private Vehicle selOption;
            private readonly Vehicle[] options;
            public VehicleViewModel()
            {
                this.options = (Vehicle[])Enum.GetValues(typeof(Vehicle));
            }
            public Vehicle[] Options { get { return options; } }
    
            public Vehicle SelectedOption
            {
                get { return selOption; }
                set
                {
                    if (selOption == value) return;
                    selOption = value;
                    OnChanged("SelectedOption");
                }
            }
        }
