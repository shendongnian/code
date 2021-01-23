    using System.Collections.Generic;
    using System.ComponentModel;
    namespace WpfApplication1
    {
      public class MainWindowVM : INotifyPropertyChanged
      {
        string selectedString;
        void NotifyPropertyChanged(string propertyName)
        {
          if (PropertyChanged == null) return;
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public string SelectedString
        {
          get { return selectedString; }
          set
          {
            selectedString = value;
            NotifyPropertyChanged("SelectedString");
          }
        }
        public List<string> MyList
        {
          get { return new List<string> { "The", "Quick", "Brown", "Fox" }; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
      }
    }
