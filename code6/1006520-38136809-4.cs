    namespace UWA.MenuFlyout.Core
    {
        using System.ComponentModel;
        using System.Runtime.CompilerServices;
    
        public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
