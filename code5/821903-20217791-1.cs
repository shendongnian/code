    DataTable dt = FromSomesource();
    var gridView = new GridView
                   {
                       ID = "Grid_" + grid.GridMasterId
                       DataSource = dt,     
                       AutoGenerateColumns = false
                   };
    gridView.RowDeleting += GridRowDeleting;
    gridView.RowEditing += GridRowEditing;
    /*
        this loop for adding data columns to gridview
    */
    CommandField cfEdit = new CommandField();    
    cfEdit.ButtonType = ButtonType.Button;
    cfEdit.ShowEditButton = true;
    cfEdit.HeaderText = "Edit";
    cfEdit.CausesValidation = false;
    gridView.Columns.Add(cfEdit);
    gridView.DataBind();
