    //sortingDirection = string.Empty;
    if (dir == SortDirection.Ascending)
    {
        //dir = SortDirection.Descending;
        sortingDirection = "Asc"; // "Desc";
    }
    else
    {
        //dir = SortDirection.Ascending;
        sortingDirection = "Desc"; // "Asc";
    }
    ...
    GridView1.DataSource = sortedView; //dset.Tables[0];
