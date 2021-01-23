    public class TabItemStyleSelector : StyleSelector
        {
            public override Style SelectStyle(object item, DependencyObject container)
            {
                var itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
                var itemIndex = itemsControl.ItemContainerGenerator.IndexFromContainer(container);
    
                //first index
                if(itemIndex == 0)
                {
                    return (Style)itemsControl.FindResource("FirstTabItemItemStyle");
                }
                //last index
                if (itemIndex == itemsControl.Items.Count - 1)
                {
                    return (Style)itemsControl.FindResource("LastTabItemItemStyle");
                }
    
                //other indecies
                return (Style)itemsControl.FindResource("OtherTabItemItemStyle");
    
                //return base.SelectStyle(item, container); return this if OtherTabItemItemStyle does not exist
            }
        }
