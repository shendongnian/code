    public class Customer : INotifyPropertyChanged
    {
    Define INotifyPropertyChanged Members,
    public event PropertyChangedEventHandler PropertyChanged;
    
    public void OnPropertyChanged(PropertyChangedEventArgs e)
    {
       if (PropertyChanged != null)
       {
         PropertyChanged(this, e);
       }
    }
