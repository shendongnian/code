          if (e.CommandName == "Delete")
            {
            if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                DataTable table = CreateDataTable(false, string.Empty, string.Empty);
                table.Rows.RemoveAt(rowIndex) 
                grdSelectedProducts.DataSource = table;
                grdSelectedProducts.DataBind();
            }
        }
