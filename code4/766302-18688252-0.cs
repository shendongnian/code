    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        using (bus_noContext ctx = new bus_noContext(bus_noContext.ConnectionString))
        {
            ctx.CreateIfNotExists();
            ctx.LogDebug = true;
            var buses = from c in ctx.Bus_routes
                             select new bus_list{ BUS_NO = c.BUS_NO, SOURCE = c.SOURCE, DESTINATION = c.DESTINATION};
            busno_list.ItemsSource = buses.ToList();
            searchbox.Text = buses[20].SOURCE; // or whatever
        }
    }
