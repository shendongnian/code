    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;    \
    ...
    
    public partial class MyWindow : Window, INotifyPropertyChanged
    {
        //Observable collection 
        private ObservableCollection<int> _arrayOfInt32;
        public ObservableCollection<int> ArrayOfInt32
        {
            get { return _arrayOfInt32; }
            set
            {
                _arrayOfInt32 = value;
                NotifyPropertyChanged();
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        ....
        //Put this line in the constructor after InitializeComponent
        this.DataContext = this;
        ArrayOfInt32 = new ObservableCollection<int>(this.Resources["arrayOfInt32"] as int[]);
        
