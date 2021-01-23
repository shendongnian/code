    public JsonResult List([ModelBinder(typeof(DataTablesBinder))] 
    IDataTablesRequest requestModel)
    {
    List<View_DFS_Akustik> myOriginalDataSet = dbman.View_DFS_Akustik.ToList();
    List<View_DFS_Akustik> myFilteredData = dbman.Set<View_DFS_Akustik>().FullTextSearch(requestModel.Search.Value).ToList();
    //Apply filter to your dataset based only on the columns that actually have a search value.
    foreach (var column in requestModel.Columns.GetFilteredColumns())
    {
        string query = column.Data + ".Contains(\"" + column.Search.Value + "\")";
        myFilteredData = myFilteredData.Where(query).ToList();
    }
    //Set your dataset on the same order as requested from client-side either directly on your SQL code or easily
    //into any type or enumeration.
    bool isSorted = false;
    foreach (var column in requestModel.Columns.GetSortedColumns())
    {
        if (!isSorted)
        {
            // Apply first sort.
            if (column.SortDirection == Column.OrderDirection.Ascendant)
                myFilteredData = myFilteredData.OrderBy(column.Data).ToList();
            else
                myFilteredData = myFilteredData.OrderBy(column.Data + " descending").ToList();
            isSorted = true;
        }
        else
        {
            if (column.SortDirection == Column.OrderDirection.Ascendant)
                myFilteredData = myFilteredData.OrderBy(column.Data).ToList();
            else
                myFilteredData = myFilteredData.OrderBy(column.Data + " descending").ToList();
        }
    }
    var paged = myFilteredData.Skip(requestModel.Start).Take(requestModel.Length);
    return Json(new DataTablesResponse(requestModel.Draw, paged, myFilteredData.Count(), myOriginalDataSet.Count()), JsonRequestBehavior.AllowGet);
    }
