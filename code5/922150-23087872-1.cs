    List<object> inactiveCustomers = new List<object>();
    foreach (Customer item in ListBoxCustomers.Items)
    {
        if (!item.IsActive)
        {
            inactiveCustomers.Add(item);
            var container = (ListBoxItem) ListBoxCustomers.ItemContainerGenerator.ContainerFromItem(item);
            container.Background = Brushes.Red;
        }
    }
