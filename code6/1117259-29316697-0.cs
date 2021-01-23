    public class ViewItem : INotifyPropertyChanged
    {
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged([CallerMemberName] string caller = "")
    {
        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(caller));
    }
    }
