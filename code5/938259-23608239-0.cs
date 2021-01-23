    gridSettings.PreRender = (sender, e) =>
    {
        MVCxGridView gridView = sender as MVCxGridView;
        if ((gridView != null) && (ViewData["selectedRows"] != null))
        {
            int[] selectedRows = (int[])ViewData["selectedRows"];
            foreach (int key in selectedRows)
            {
                 gridView.Selection.SelectRowByKey(key);
            }
        }
    };    
