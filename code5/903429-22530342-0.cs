    if (e.CommandName == "Delete")
        {
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                grdSelectedProducts.DeleteRow(rowIndex);
                SqlCommand cmd = new SqlCommand ("Delete from table where id='"+ rowIndex )+"'",ConnectionObject);
                cmd.ExecutenonQuery();
                CountryDataTable = (DataTable)grdSelectedProducts.DataSource;
                DataTable table = CreateDataTable(false, string.Empty, string.Empty);
                grdSelectedProducts.DataSource = table;
                grdSelectedProducts.DataBind();
            }
        }
