       public class MyViewModel : BindableBase
    {
        private string _firstName;
        private string _lastName;
 
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
 
     
    }
         //Inside Bindable Base
        public abstract class BindableBase : INotifyPropertyChanged
        {
           public event PropertyChangedEventHandler PropertyChanged;
           protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
           {
              if (Equals(storage, value))
              {
                 return false;
              }
              storage = value;
              this.OnPropertyChanged(propertyName);
              return true;
           }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
          PropertyChangedEventHandler eventHandler = this.PropertyChanged;
          if (eventHandler != null)
          {
              eventHandler(this, new PropertyChangedEventArgs(propertyName));
          }
        }
    }
