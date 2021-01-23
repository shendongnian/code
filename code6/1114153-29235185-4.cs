    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication2
    {
        /// <summary>
        ///     Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class UserControl1 : UserControl, INotifyPropertyChanged
        {
            private DelegateCommand _myCommand;
    
            public UserControl1()
            {
                InitializeComponent();
    
                MyCommand = new DelegateCommand(Execute);
            }
    
            public DelegateCommand MyCommand
            {
                get { return _myCommand; }
                set
                {
                    _myCommand = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void Execute(object o)
            {
                MessageBox.Show("Hello");
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
