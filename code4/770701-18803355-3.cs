    protected void gvLogNotice_sorting(object sender, GridViewSortEventArgs e)
    {
        switch (e.SortExpression)
        {
            case "DateLogged":
                if (e.SortDirection == SortDirection.Ascending)
                {
                   LoadGrid("DateLogged", "ASC");
                }
                else
                {
                    LoadGrid(e.SortExpression, "DESC");
                }
                break;
           }
    }
