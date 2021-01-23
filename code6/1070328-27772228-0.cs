    using System.ComponentModel;
    namespace SimpleViewModel
    {
        public class ViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged(string propertyName)
            {
                var local = PropertyChanged;
                if (local != null)
                {
                    local.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            protected string result;
            public string Result
            {
                get
                {
                    return result;
                }
                set
                {
                    if (string.Equals(result, value))
                    {
                        return;
                    }
                    result = value;
                    RaisePropertyChanged("Result");
                }
            }
        }
    }
