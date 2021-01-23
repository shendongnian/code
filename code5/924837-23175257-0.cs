    DateTime temp;
    // try to parse the provided string in order to convert it to datetime
    // if the conversion succeeds, then build the dateFilter
    if(DateTime.TryParse(TrystartDate.Text, out temp))
    {
        string dateFilter = temp.ToString("dd/MM/yyyy");
        var filteredList = images.Where(item => item.Date == dateFilter);
        var filterSource = new BindingSource();
        filterSource.DataSource = filteredList;
        navigationGrid.DataSource = filterSource;
    }
         
