    public partial class MainWindow : INotifyPropertyChanged
        {
    
            ...
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                CanSelectNext = true;
                OnPropertyChanged("CanSelect");    
            }
    
            public bool CanSelectNext { set; get; }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            ...
        }
