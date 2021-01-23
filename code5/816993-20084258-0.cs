    //XAML
    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
            Title="MainWindow" Height="350" Width="525">
        <StackPanel>
            <TextBox x:Name="TextBox1" Width="200" HorizontalAlignment="Left" Text="{Binding TextValue, UpdateSourceTrigger=PropertyChanged}"></TextBox>
            <ComboBox x:Name="ComboBox1" HorizontalAlignment="Left" ItemsSource="{Binding Items}" SelectedValue="{Binding SelectedValue, UpdateSourceTrigger=PropertyChanged}" Width="200"/>
            <Button x:Name="Button1" HorizontalAlignment="Left" Content="Save" Command="{Binding ClickCommand}" Width="116"/>
        </StackPanel>
    </Window>
    //
    //
    //ViewModel
    public class MainViewModel : INotifyPropertyChanged
        {
            private IList<string> _items;
            private bool _canExecute;
            private ICommand _clickCommand;
            private string _textValue;
            private string _selectedValue;
    
            public IList<string> Items
            {
                get { return _items; }
            }
    
            public string SelectedValue
            {
                get { return _selectedValue; }
                set 
                { 
                    _selectedValue = value;
                    OnPropertyChanged("SelectedValue");
                }
            }
            public string TextValue
            {
                get { return _textValue; }
                set { 
                    _textValue = value;
                OnPropertyChanged("TextValue");}
            }
            public void Save()
            {
                SelectedValue = _items.FirstOrDefault();
                TextValue = "Значение по умолчанию";
            }
    
            public ICommand ClickCommand
            {
                get { return _clickCommand ?? (new RelayCommand(() => Save(), _canExecute)); }
            }
    
            public MainViewModel()
            {
                _items = new List<string> { "Test1", "Test2", "Test3" };
                _selectedValue = _items.First();
                _textValue = "Значение по умолчанию";
                _canExecute = true;
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class RelayCommand : ICommand
        {
            private Action _action;
            private bool _canExecute;
            public RelayCommand(Action action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }
    
            public event EventHandler CanExecuteChanged;
    
            public void Execute(object parameter)
            {
                _action();
            }
        }
