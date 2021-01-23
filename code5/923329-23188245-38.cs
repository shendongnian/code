	public partial class UserControl1 : UserControl
	{
		public static readonly RoutedCommand DeleteCommand = new RoutedCommand("UserControl1Command.Delete", typeof(UserControl1));
		
		...same implementation approach as demonstrated for CRUDDataGrid1.AddCommand...
	}
