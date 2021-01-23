    using System;
    using System.ComponentModel;
    
    namespace WpfApplication1.ViewModels
    {
        public class TestViewModel : INotifyPropertyChanged
        {
            public TestViewModel()
            {
                RefreshFromView = new RelayCommand(ExecuteRefreshFromView);
            }
    
            public Action RefreshAction { get; set; }
    
            public RelayCommand RefreshFromView { get; set; }
            private void ExecuteRefreshFromView(object parameter)
            {
                if (RefreshAction != null)
                    RefreshAction();
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyOfPropertyChange(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
