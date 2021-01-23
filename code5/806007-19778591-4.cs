    public class Owner : INotifyPropertyChanged, INotifyDataErrorInfo
    {
       public Owner()
       {
          FailedRules = new Dictionary<string, string>();
       }
 
       private Dictionary<string, string> FailedRules
       {
          get;
          set;
       }
       public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    
       public IEnumerable GetErrors(string propertyName)
       {
          if (FailedRules.ContainsKey(propertyName))
             return FailedRules[propertyName];
          else
             return FailedRules.Values;
       }
       internal void FireValidation()
       {
          if (lastName.Length > 20)
          {
             if (!FailedRules.ContainsKey("LastName"))
                FailedRules.Add("LastName", "Last name cannot have more than 20 characters");
          }
          else
          {
             if (FailedRules.ContainsKey("LastName"))
                FailedRules.Remove("LastName");
          }
          
          NotifyErrorsChanged("LastName");
       }
    
       public bool HasErrors
       {
          get { return FailedRules.Count > 0; }
       }
    
       private void NotifyErrorsChanged(string propertyName)
       {
          if (ErrorsChanged != null)
             ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
       }
    }
