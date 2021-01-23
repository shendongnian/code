    public class AcquisitionParameters : INotifyPropertyChanged
    {
      private Choice1 options;
      private Choice2 filterType;
      private bool customParametersEnabled;
    
      public Choice1 Options
      {
         get { return options; }
         set 
         { 
            options= value; 
            CustomParametersEnabled = options == Choice1.Options1;
            OnPropertyChanged("Options"); 
            OnPropertyChanged("CustomParametersEnabled "); 
         }
      }
    
      public Choice2 FilterType
      {
         get { return filterType; }
         set { filterType= value; OnPropertyChanged("FilterType"); }
      }
    
      public bool CustomParametersEnabled
      {
         get { return customParametersEnabled; }
         set { customParametersEnabled = value; OnPropertyChanged("CustomParametersEnabled"); }
      }
    }
