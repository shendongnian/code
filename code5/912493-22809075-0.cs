    public class ViewModel: INotifyPropertyChanged
    {
       private List<bool> myBooleanCollection;
       public List<bool> MyData
       {
          get { return myBooleanCollection;  }
          set { myBooleanCollection = value; }
       }
       private bool _allowMultiple;
    
       public bool AllowMultiple
       {
          get { return _allowMultiple; }
          set
          {
             if (_allowMultiple != value)
             {
                _allowMultiple = value;
                OnPropertyChanged("AllowMultiple");
             }
          }
       }
    }
