    List<OrderTripChangedAlertItem> da = new List<OrderTripChangedAlertItem>();
        
    BindingList bl = new BindingList<OrderTripChangedAlertItem>(da);
    BindingSource bs = new BindingSource();
    bs.DataSource = bl;
        
    GridView.DataSource = bs;
    
    da.Add(new OrderTripChangedAlertItem(1, "2", "3"));
