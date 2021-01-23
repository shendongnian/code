    public class MainVm:INotifyPropertyChanged
    {
        List<Point> _points;
        public List<Point> Points
        {
            get { return _points; }
            set { _points = value; Notify("Points"); }
        }
        public void Notify(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
