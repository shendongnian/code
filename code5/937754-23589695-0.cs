     using (SqlConnection connection = new SqlConnection("Data Source=baaa;Initial Catalog=InventorySystem;Integrated Security=True")
        {
            connection.Open();
    
            using (SqlCommand command = new SqlCommand(
            "SELECT product.P_ID, Product.P_Name,Product.Leadtime, Product.SafetyStockamount," +
            "Monthlysales.Month, Monthlysales.totalsalesamount, (totalsalesamount/30) as Averagedailysales, ((totalsalesamount/30) * Leadtime + SafetyStockamount) as reorderpoint " +
            "FROM Product, Monthlysales " +
            "where Product.P_ID = Monthlysales.P_ID AND Product.P_ID =@P_ID AND Monthlysales.Month =@Month ", connection))
            {
    
                command.Parameters.Add(new SqlParameter("P_ID", pid));
                command.Parameters.Add(new SqlParameter("Month", Startmonth));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
            }
        }
