    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    
    namespace WpfApp6
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ViewModel viewModel;
    
            public MainWindow()
            {
                InitializeComponent();
    
                viewModel = new ViewModel();
    
                foreach (var item in new string[] { "A", "B", "C", "D"})
                {
                    viewModel.CheckComboBoxItems.Add(new CheckComboBoxItems { IsChecked = false, Item = item}); 
                }
    
                DataContext = viewModel;
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {   
                foreach (var checkBoxToSet in viewModel.CheckComboBoxItems)
                {
                    if (checkBoxToSet.Item.Equals("A") || checkBoxToSet.Item.Equals("C"))
                    {
                        checkBoxToSet.IsChecked = true;
                    }
                }
            }
        }
    
        public class ViewModel
        {
            public ObservableCollection<CheckComboBoxItems> CheckComboBoxItems { get; set; } = new ObservableCollection<CheckComboBoxItems>();
        }
    
        public class CheckComboBoxItems : INotifyPropertyChanged
        {
            private bool _isChecked;
            private string _item;
    
            public bool IsChecked
            {
                get
                {
                    return _isChecked;
                }
                set
                {
                    _isChecked = value;
                    NotifyPropertyChanged("IsChecked");
                }
            }
    
    
            public string Item
            {
                get
                {
                    return _item;
                }
                set
                {
                    _item = value;
                    NotifyPropertyChanged("Item");
                }
            }
    
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
