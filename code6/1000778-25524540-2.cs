    using System.ComponentModel;
    namespace WpfApplication1
    {
        public class LoadDataViewModel : INotifyPropertyChanged
        {
            private bool isLoadingData = false;
            public bool IsLoadingData
            {
                get { return isLoadingData; }
                set
                {
                    if (value != isLoadingData)
                    {
                        isLoadingData = value;
                        PropertyChanged(this, new PropertyChangedEventArgs("IsLoadingData"));
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
        }
    }
