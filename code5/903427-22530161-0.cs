          if (e.CommandName == "Delete")
            {
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                DataTable table = CreateDataTable(false, string.Empty, string.Empty);
                table.Rows.Remove(rowIndex) //May be u will have a syntax error here:D , just remove it from table thats what i mean
                grdSelectedProducts.DataSource = table;
                grdSelectedProducts.DataBind();
            }
        }
