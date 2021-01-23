    void Window_Loaded(object sender, RoutedEventArgs e)
    {
    	List<object> inactiveCustomers = new List<object>();
    	foreach (Customer item in ListBoxCustomers.Items)
    	{
    		if (!item.IsActive)
    		{
    			inactiveCustomers.Add(item);
    			ListBoxItem x = ListBoxCustomers.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
    			if (x != null)
    				x.Background = Brushes.Red;
    		}
    	}
    }
