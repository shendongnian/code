    public class EmptyClass
    	{
    		public ObservableCollection<HubTileItem> HubTiles { get; set; }
    
    		public EmptyClass()
    		{
    			HubTiles = new ObservableCollection<HubTileItem>();
    			HubTiles.Add(new HubTileItem { Title = "Tile1", HubTileTap = () => HubTileTap() };);
    		}
    
    		public void HubTileTap()
    		{
    		}
    	}
    
    	public class HubTileItem
    	{
    		public string Title { get; set; }
    
    		public Action HubTileTap { get; set; }
    	}
