	public partial class CRUDDataGrid1 : UserControl
	{
		public static readonly RoutedCommand AddCommand = new RoutedCommand("CRUDDataGridCommand.Add", typeof(CRUDDataGrid1));
		
		public UserControl1()
		{
			InitializeComponent();
			
			CommandBindings.Add(
				new CommandBinding(
				    AddCommand,
				    OnExecutedAddCommand,
				    CanExecuteAddCommand
				)
			);
				
			...other constructor code...
		}
		
		private void CanExecuteAddCommand(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = ...here your code that decides whether the "Add" command can execute
			               (and thus whether any button which uses this command will be enabled/disabled)
		}
		
		private void CanExecuteAddCommand(object sender, ExecutedRoutedEventArgs e)
		{
			...execute the "Add" action here...
		}
	}
