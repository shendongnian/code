    public class MyViewModel : INotifyPropertyChanged
    {
    public MyViewModel()
    {
        StartValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        EndValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
    }
    private DateTime _dateTime1;
    public DateTime StartValue
    {
        get
        {
            return _dateTime1;
        }
        set
        {
            if (_dateTime1.Equals(value)) return;
            _dateTime1 = value; 
            OnPropertyChanged("StartValue");
        }
    }
    private DateTime _dateTime2;
    public DateTime EndValue
    {
        get
        {
            return _dateTime2;
        }
        set
        {
            if (_dateTime2.Equals(value)) return;
            _dateTime2 = value;
            OnPropertyChanged("EndValue");
        }
    }
    protected virtual void OnPropertyChanged(String time)
    {
        if (System.String.IsNullOrEmpty(time))
        {
            return;
        }
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(time));
        }
    }
    #region INotifyPropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion
    }
