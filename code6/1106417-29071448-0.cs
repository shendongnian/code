    public class BottomData : DependencyObject, INotifyPropertyChanged
    {
        public string Name { get; set; }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(BottomData), new PropertyMetadata(0d,new PropertyChangedCallback(OnValueChanged)));
        public double Value
        {
            get { return (double)this.GetValue(ValueProperty); }
            set { base.SetValue(ValueProperty, value); }
        }
        public BottomData(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BottomData bd = d as BottomData;
            bd.NotifyPropertyChanged("Value");
        }
        void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
