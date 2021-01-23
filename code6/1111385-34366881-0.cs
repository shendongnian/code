    public partial class App : Application
    {
    	protected override void OnStartup(StartupEventArgs e)
    	{
    		ThemeManager.ChangeAppStyle(this,
    									ThemeManager.GetAccent("Amber"),
    									ThemeManager.GetAppTheme("BaseDark"));
    
   			var allTypes = typeof(App).Assembly.GetTypes();
   			var filteredTypes = allTypes.Where(d =>
   				typeof(MetroWindow).IsAssignableFrom(d)
   				&& typeof(MetroWindow) != d
   				&& !d.IsAbstract).ToList();
    
   			foreach (var type in filteredTypes)
   			{
   				var defaultStyle = this.Resources["MetroWindowDefault"];
   				this.Resources.Add(type, defaultStyle);
   			}
   
   			base.OnStartup(e);
   		}
   	}
