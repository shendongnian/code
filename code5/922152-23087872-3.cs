    List<object> inactiveCustomers = new List<object>();
    foreach (Customer item in ListBoxCustomers.Items)
    {
        if (!item.IsActive)
        {
            inactiveCustomers.Add(item);
            var container =  ListBoxCustomers.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
            if (container != null)
                container.Background = Brushes.Red;
        }
    }
