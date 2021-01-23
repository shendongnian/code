    public class TabbedContainer : IControlCollectionContainer
    {
        public List<TabItem> Items { get; set; } 
    
        List<IControlSingleContainer> IControlCollectionContainer.Items 
        { 
            get 
            { 
                return // Your actual tab items 
            }
 
            set 
            { 
                 Items = //Whatever you need to do make sure you have actual
                         // TabItem objects
            }
        }
    }
