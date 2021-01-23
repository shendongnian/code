    protected void PopulateGridView<T>(GridView grid, DbSet entityTable)
    {
        string columnToSortBy = (string)(ViewState["gridview_sortbycolumn"] ?? string.Empty);
        SortDirection sortDirection = (SortDirection)(ViewState["gridview_sortdirection"] ?? SortDirection.Descending);
        int pageIndex = (int)(ViewState["gridview_pageindex"] ?? 0);
        
        if (columnToSortBy != string.Empty)
        {
            grid.DataSource = entityTable.OrderBy(columnToSortBy + " " + sortDirection).Cast<T>().ToList();
        }
        else
        {
            // use linq reflection to get the first entity field name to sort by
            string defaultColumn = string.Empty;
            foreach (var field in typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
            {
                defaultColumn = field.Name.Remove(field.Name.IndexOf(">")).Replace("<", string.Empty);
                break;
            }
            grid.DataSource = entityTable.OrderBy(defaultColumn).Cast<T>().ToList();
        }
        grid.PageIndex = pageIndex;
        grid.DataBind();
    }
