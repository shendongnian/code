    public class MyDomainObjectViewModel : INotifyPropertyChanged {
      private MyDomainObject _domainObject;
      public MyDomainObjectViewModel(MyDomainObject domainObject){
        _domainObject = domainObject;
      }
      public DateTime StartDate { 
        get{
          return _domainObject.StartDate;
        }
        set{
          _domainObject.StartDate = value;
          RaisePropertyChanged("StartDate");
          RaisePropertyChanged("IsActive");
        }
      }
      public DateTime EndDate { 
        get{
          return _domainObject.EndDate ;
        }
        set{
          _domainObject.EndDate = value;
          RaisePropertyChanged("EndDate");
          RaisePropertyChanged("IsActive");
        }
      }
      public bool IsActive {
        get { return StartDate < DateTime.Now && EndDate > DateTime.Now; }
      }
    }
