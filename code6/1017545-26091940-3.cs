        string[] VisibleColumns = //Here populate string array with list of columns you want to show
        if (e != null)
        {
            if (!VisibleColumns.Contains(e.Column.Header))
            {
                e.Cancel = true;
            }
        }
