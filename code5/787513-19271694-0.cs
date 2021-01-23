    [Export]
    public class PluginService
    {
       public const string BEST_PLUGIN = "BestPlugin";
    
       [ImportMany]
       public IEnumerable<Plugin> Plugins{ private get; set; }
    
       [Export(BEST_PLUGIN)]
       public Plugin BestPlugin{ get { return GetBestPlugin(); } }
       Plugin GetBestPlugin()
       {
           return Plugins.FirstOrDefault(); //or some other logic for selection
       }
    }
