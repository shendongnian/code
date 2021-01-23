    interface IObjectWithOnPropertyChangedMethod
    {
      void OnPropertyChanged(string propertyName);
    }
    
    public class MyPoco : INotifyPropertyChanged, IObjectWithOnPropertyChangedMethod
    {
      //// Implementation of IObjectWithOnPropertyChangedMethod interface
      public void OnPropertyChanged(string propertyName)
      {
        if(PropertyChanged != null)
        {
           PropertyChanged(.....);
        }
      }
    
     //// Implementation of INotifyPropertyChanged interface
     public event PropertyChanged;
    }
