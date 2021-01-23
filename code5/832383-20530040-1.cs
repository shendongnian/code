    public class ItemsTabViewModel : Conductor<IScreen>.Collection.AllActive 
    {
        public ItemsViewModel ItemsExplorer { get; set; }
        public ExplorerPanelViewModel PanelView { get; set; }
        // Ctor etc.
    }
