    public class ExtendedItemsControl : ItemsControl
    {
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            var item2 = this.ItemContainerGenerator.ContainerFromItem(e.NewItems[1]);
            Grid.SetColumn(item2, 1);
            var item3 = this.ItemContainerGenerator.ContainerFromItem(e.NewItems[2]);
            Grid.SetColumn(item3, 2);
            Grid.SetColumnSpan(item3, 2);
            var item4 = this.ItemContainerGenerator.ContainerFromItem(e.NewItems[3]);
            Grid.SetRow(item4, 1);
            // etc ...
        }
    }
