    ViewableCollection<ICustomer> vCustomers = new ViewableCollection<ICustomer>();
    // Sorting settings:
    ViewableCollection<ICustomer> vCustomers.View.SortDescriptions.Add(new SortDescription("CustomerName", ListSortDirection.Ascending));
    vCustomers.View.Filter = MyCustomFilterMethod;
    // add data to collection
    MyCustomers.ToList().ForEach(customer => vCustomers.Add(customer));
