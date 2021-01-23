    public class MyViewModel : INotifyPropertyChanged
    {
        private string _zValue;
        private string _yValue;
        private string _xValue;
        public string XValue
        {
            get { return _xValue; }
            set { _xValue = value; NotifyPropertyChanged("XValue"); }
        }
        public string YValue
        {
            get { return _yValue; }
            set { _yValue = value; NotifyPropertyChanged("YValue"); }
        }
        public string ZValue
        {
            get { return _zValue; }
            set { _zValue = value; NotifyPropertyChanged("ZValue"); }
        }
        void _accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            var position = e.SensorReading.Acceleration;
            SmartDispatcher.Dispatch(() =>
            {
                this.XValue = position.X.ToString("0.0000");
                this.YValue = position.Y.ToString("0.0000");
                this.ZValue = position.Z.ToString("0.0000");
            });
        }
     
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
