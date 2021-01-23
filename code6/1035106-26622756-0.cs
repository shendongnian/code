    using Windows.UI.Xaml;
    using System.ComponentModel;
    // very simple view model
    class MyViewModel : DependencyObject, INotifyPropertyChanged
    {
        // implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        // register
        public static DependencyProperty FooterTitleProperty = DependencyProperty.Register("FooterTitle", typeof(string), typeof(MyViewModel),
             new PropertyMetadata(string.Empty, OnFooterTitlePropertyChanged));
        
        // the actual property
        public string FooterTitle
        {
            get { return (string) GetValue(FooterTitleProperty); }
            set
            {
                SetValue(FooterTitleProperty, value);
            }
        }
        // this will fire when the property gets change
        // it will call the OnPropertyChanged to notify the UI element to update its layout
        private static void OnFooterTitlePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            MyViewModel mvm = dependencyObject as MyViewModel;
            mvm.OnPropertyChanged("FooterTitle");
        }
    }
