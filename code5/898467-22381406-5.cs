    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    namespace YourNamespace
    {
        public class UserPrefParameters : INotifyPropertyChanged
        {
            public static readonly UserPrefParameters Instance;
            public bool HighContrast
            {
                get { return SystemParameters.HighContrast; }
            }
            static UserPrefParameters()
            {
                Instance = new UserPrefParameters();
            }
            public UserPrefParameters()
            {
                SystemParameters.StaticPropertyChanged += SystemParametersOnStaticPropertyChanged;
            }
            private void SystemParametersOnStaticPropertyChanged(object sender, PropertyChangedEventArgs args)
            {
                if (args.PropertyName == "HighContrast")
                    OnPropertyChanged(args.PropertyName);
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
