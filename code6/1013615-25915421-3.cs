    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new ViewModel();
		}
	}
	public class MenuItem
	{
		public MenuItem()
		{
			Items = new ObservableCollection<MenuItem>();
		}
		public string Title { get; set; }
		public ICommand Command { get; set; }
		public ObservableCollection<MenuItem> Items { get; private set; }
	}
	public class ViewModel
	{
		public ViewModel()
		{
			Nodes = new ObservableCollection<Node>
			{
				new Node("MSSQL", NodeType.Database,
					new Node("Customers", NodeType.Table)),
				new Node("Oracle", NodeType.Database)
			}; 
		}
		public ObservableCollection<Node> Nodes { get; set; }
	}
	public enum NodeType
	{
		Database,
		Table,
	}
	public class Node
	{
		public string Title { get; protected set; }
		public NodeType Type { get; protected set; }
		public ObservableCollection<Node> Nodes { get; set; }
		public Node(string title, NodeType type, params Node[] nodes)
		{
			this.Title = title;
			this.Type = type;
			this.Nodes = new ObservableCollection<Node>();
			if (nodes != null)
				nodes.ToList().ForEach(this.Nodes.Add);
		}
		public IEnumerable<MenuItem> ContextMenu
		{
			get { return createMenu(this); }
		}
		private static IEnumerable<MenuItem> createMenu(Node node)
		{
			switch (node.Type)
			{
				case NodeType.Database:
					return new List<MenuItem>
					{
						new MenuItem {Title = "Create table...",  Command = new RelayCommand(o => MessageBox.Show("Table created"))}
					};
				case NodeType.Table:
					return new List<MenuItem>
					{
						new MenuItem {Title = "Select..."},
						new MenuItem {Title = "Edit..."}
					};
				default:
					return null;
			}
		}
	}
	public class RelayCommand : ICommand
	{
		#region Fields
		readonly Action<object> _execute;
		readonly Predicate<object> _canExecute;
		#endregion // Fields
		#region Constructors
		public RelayCommand(Action<object> execute)
			: this(execute, null)
		{
		}
		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");
			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors
		#region ICommand Members
		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		public void Execute(object parameter)
		{
			_execute(parameter);
		}
		#endregion // ICommand Members
	}
