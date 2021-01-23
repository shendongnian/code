    public class ViewModel
    	{
    		public PermissionGroup PG {get; set;}
    		public ViewModel()
    		{
    			PG = new PermissionGroup();
    			PG.Icon= System.Net.WebUtility.HtmlDecode("&#xE1D4;");
    		}
    	}
	
    public partial class Window1 : Window
    	{
    		public Window1()
    		{
    			InitializeComponent();
    			this.DataContext = new ViewModel();
    		}
    	}
	<TextBlock Text="{Binding Path=PG.Icon}" />
