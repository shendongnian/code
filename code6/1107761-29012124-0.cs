    public class Notifier : INotifyPropertyChanged {
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void RaisePropertyChanged( string propertyName ) {
        if ( PropertyChanged != null ) {
            PropertyChanged(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
