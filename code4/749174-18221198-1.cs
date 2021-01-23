    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    
    namespace WpfApplication8
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private ContractModel _selectedItem;
            private ObservableCollection<ContractModel> _contractDataList = new ObservableCollection<ContractModel>();
    
            public MainWindow()
            {
                InitializeComponent();
    
                //foreach (var contactdata in RootObject_1.results)
                for (int i = 0; i < 30; i++)
                {
                    var model = new ContractModel
                    {
                        Name = "name" + i,
                        Address = "address" + i,
                        Reference = i.ToString()
                    };
                    ContractDataList.Add(model);
                }
            }
    
            public ObservableCollection<ContractModel> ContractDataList
            {
                get { return _contractDataList; }
                set { _contractDataList = value; }
            }
    
            public ContractModel SelectedItem
            {
                get { return _selectedItem; }
                set { _selectedItem = value; NotifyPropertyChanged("SelectedItem"); }
            }
            
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
    
        public class ContractModel : INotifyPropertyChanged
        {
            private string _name;
            private string _address;
            private string _reference;
    
            public string Name
            {
                get { return _name; }
                set { _name = value; NotifyPropertyChanged("Name"); }
            }
    
            public string Address
            {
                get { return _address; }
                set { _address = value; NotifyPropertyChanged("Address"); }
            }
    
            public string Reference
            {
                get { return _reference; }
                set { _reference = value; NotifyPropertyChanged("Reference"); }
    
    
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
