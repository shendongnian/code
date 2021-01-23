    namespace WpfApplication8
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ObservableCollection<TestObject> myVar = new ObservableCollection<TestObject>();
    
            public MainWindow()
            {
                MyButtonCommand = new RelayCommand(ExecuteButtonAction, CanButtonExecute);
                InitializeComponent();
    
                for (int i = 0; i < 100; i++)
                {
                    Activities.Add(new TestObject { Column1 = "Item" + i, Enabled = false });
                }
            }
    
            public ICommand MyButtonCommand { get; set; }
    
            public ObservableCollection<TestObject> Activities
            {
                get { return myVar; }
                set { myVar = value; }
            }
    
            private bool CanButtonExecute()
            {
                return Activities.Any(x => x.Enabled) && Activities.Any(x => x.Column1 == "Item2");
            }
    
            private void ExecuteButtonAction()
            {
                // button clicked
            }
        }
    
    
        public class TestObject : INotifyPropertyChanged
        {
            
            private string _column1;
            private bool _enabled;
    
            public string Column1
            {
                get { return _column1; }
                set { _column1 = value; NotifyPropertyChanged(); }
            }
    
            public bool Enabled
            {
                get { return _enabled; }
                set { _enabled = value; NotifyPropertyChanged(); }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;
    
            /// <summary>
            /// Creates a new command that can always execute.
            /// </summary>
            /// <param name="execute">The execution logic.</param>
            public RelayCommand(Action execute)
                : this(execute, null)
            {
            }
    
            /// <summary>
            /// Creates a new command.
            /// </summary>
            /// <param name="execute">The execution logic.</param>
            /// <param name="canExecute">The execution status logic.</param>
            public RelayCommand(Action execute, Func<bool> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");
    
                _execute = execute;
                _canExecute = canExecute;
            }
    
            [DebuggerStepThrough]
            public bool CanExecute(object parameter)
            {
                return _canExecute == null ? true : _canExecute();
            }
    
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    if (_canExecute != null)
                    {
                        CommandManager.RequerySuggested += value;
                    }
                }
                remove
                {
                    if (_canExecute != null)
                    {
                        CommandManager.RequerySuggested -= value;
                    }
                }
            }
    
            public void Execute(object parameter)
            {
                _execute();
            }
        }
    
    }
