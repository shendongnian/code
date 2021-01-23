    <Label x:Name="lbl_CurrentVelOutput" />
     public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            velocity vel = new velocity() {AngleOfTravel= 50.5};
            Binding(vel, lbl_CurrentVelOutput, "AngleOfTravel");
        }
        private void Binding(velocity Object, Label Output, string Field)
        {
            Binding newBinding = new Binding();
            newBinding.Source = Object;
            newBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            newBinding.Path = new PropertyPath(Field);
            newBinding.Mode = BindingMode.TwoWay;
            Output.SetBinding(Label.ContentProperty, newBinding);
        }
    }
    public class velocity : INotifyPropertyChanged
    {
        private double _AngleOfTravel;
        public double AngleOfTravel
        {
            get { return _AngleOfTravel; }
            set
            {
                _AngleOfTravel = value;
                OnPropertyChanged("AngleOfTravel");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null)
            {
                Handler(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
