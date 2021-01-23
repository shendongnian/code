    using System.Collections.Generic;
    using System.ComponentModel;
    namespace WpfApplication1
    {
      public class MainWindowVM : INotifyPropertyChanged
      {
        string selectedString;
        List<string> myList = new List<string> { "The", "Quick", "Brown", "Fox" };
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
          get { return myList; }
          set
          {
            myList = value;
            NotifyPropertyChanged("MyList");
          }
        }
        public event PropertyChangedEventHandler PropertyChanged;
      }
    }
