    var grd = new GridView();
    grd.AutoGenerateColumns = false;
    BoundField field = new BoundField();
    field.DataField = "CustomerName";
    field.HeaderText = Resources.GlobalResources.Customer;
    DataControlField col = field;
    grd.Columns.Add(col);
    grd.DataSource = sortedCustomers;
    grd.DataBind();
