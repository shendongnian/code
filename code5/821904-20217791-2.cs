    DataTable dt = FromSomesource();
    var gridView = new GridView
                   {
                       ID = "Grid_" + grid.GridMasterId
                       DataSource = dt,     
                       AutoGenerateEditColumn = true
                   };
    gridView.RowDeleting += GridRowDeleting;
    gridView.RowEditing += GridRowEditing;
    gridView.DataBind();
