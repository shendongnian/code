     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();           
        }
    }
    class MainViewModel
    {
        public List<SomeClass> SwitchAgents { get; set; }
        public MainViewModel()
        {
            SwitchAgents = new List<SomeClass>();
            SomeClass obj = new SomeClass();
            obj.SomeProperty = "Test";
            List<ContextMenuItem> lst = new List<ContextMenuItem>();
            lst.Add(new ContextMenuItem() { ItemHeader = "Hi", ItemAction = new BaseCommand(MenuClick) });
            obj.ContextMenuItems = lst;
            SwitchAgents.Add(obj);
        }
        void MenuClick(object obj)
        {
            // Do Menu Click Stuff
        }
    }
    class ContextMenuItem
    {
        public string ItemHeader { get; set; }
        public ICommand ItemAction { get; set; }
    }
    class SomeClass
    {
        public List<ContextMenuItem> ContextMenuItems { get; set; }
        public string SomeProperty { get; set; }
        public string SomeAnotherProperty { get; set; }
    }
    public class BaseCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _method;
        public event EventHandler CanExecuteChanged;
        public BaseCommand(Action<object> method)
            : this(method, null)
        {
        }
        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
    }
