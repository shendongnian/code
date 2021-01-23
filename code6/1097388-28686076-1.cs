     public class TabbedContainer : IControlCollectionContainer
        {
            public TabbedContainer()
            {
                Items = new List<IControlSingleContainer>();
                var t = new TabItem();
                Items.Add(t);
            }
    
            public List<IControlSingleContainer> Items { get; set; }
        }
