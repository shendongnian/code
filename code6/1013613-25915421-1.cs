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
	public interface IContextMenuBuilder
	{
		IEnumerable<MenuItem> CreateMenu(Node node);
	}
	public class ViewModel: IContextMenuBuilder
	{
		public ViewModel()
		{
			Nodes = new ObservableCollection<Node>
			{
				new Node("MSSQL", NodeType.Database, this,
					new Node("Customers", NodeType.Table, this)),
				new Node("Oracle", NodeType.Database, this)
			}; 
		}
		public ObservableCollection<Node> Nodes { get; set; }
		public IEnumerable<MenuItem> CreateMenu(Node node)
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
	public enum NodeType
	{
		Database,
		Table,
	}
	public class Node
	{
		private readonly IContextMenuBuilder _menuBuilder;
		public string Title { get; protected set; }
		public NodeType Type { get; protected set; }
		public ObservableCollection<Node> Nodes { get; set; }
		public Node(string title, NodeType type, IContextMenuBuilder menuBuilder, params Node[] nodes)
		{
			_menuBuilder = menuBuilder;
			this.Title = title;
			this.Type = type;
			this.Nodes = new ObservableCollection<Node>();
			if (nodes != null)
				nodes.ToList().ForEach(this.Nodes.Add);
		}
		public IEnumerable<MenuItem> ContextMenu
		{
			get { return _menuBuilder.CreateMenu(this); }
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
