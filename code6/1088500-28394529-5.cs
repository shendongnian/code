    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                ViewModel viewModel = new ViewModel();
                viewModel.Parties.Add(new Party() { Name = "Joe", Surname = "Redgate" });
                viewModel.Parties.Add(new Party() { Name = "Mike", Surname = "Blunt" });
                viewModel.Parties.Add(new Party() { Name = "Gina", Surname = "Barber" });
    
                DataContext = viewModel;
    
                Binding binding = new Binding("DataContext.SelectAll");
                binding.Mode = BindingMode.TwoWay;
                binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor);
                binding.RelativeSource.AncestorType = GetType();
                
                CheckBox headerCheckBox = new CheckBox();
                headerCheckBox.Content = "Is Selected";
                headerCheckBox.SetBinding(CheckBox.IsCheckedProperty, binding);
                
                DataGridCheckBoxColumn checkBoxColumn = new DataGridCheckBoxColumn();
                checkBoxColumn.Header = headerCheckBox;
                checkBoxColumn.Binding = new Binding("IsSelected");
    
    
                dataGrid.Columns.Insert(0, checkBoxColumn);
            }
        }
    }
