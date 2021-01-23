    public class ExplorerPanelViewModel : Conductor<IScreen>.Collection.OneActive,
        IHandle<ItemSelectedEvent> // More events.
    {
        public ItemViewModel ItemInfo { get; set; }
        public CategoryFolderViewModel CategoryFolderInfo { get; set; }
        public ExplorerPanelViewModel()
        {
            // My helper to access the `Caliburn.Micro` EventAggregator.
            EventAggregatorFactory.EventAggregator.Subscribe(this);
            // Other code
        }
        public void Handle(ItemSelectedEvent message)
        {
            // Other code to check active status
                ItemInfo = message.selected;
                ActivateItem(ItemInfo);
        }
        protected override void OnDeactivate(bool close)
        {
            Debug.WriteLine("Deactivated " + this.ToString() + close.ToString());
            if (close) { EventAggregatorFactory.EventAggregator.Unsubscribe(this); }
            base.OnDeactivate(close);
        }
        // Other code
    }
