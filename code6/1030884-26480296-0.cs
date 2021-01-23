    OrderHistory OH = new OrderHistory();
    public void viewOrderHistory(int id)
    {
        
        DataGridView orderHistoryProductDataGrid = OH.dataGridView2;
        try
        {
            DatabaseConnection();//Database connection
            string ord = "SELECT * FROM Orders_Products WHERE ID=@ID";
            SqlCommand ordPro = new SqlCommand(ord, myCon);
            ordPro.Parameters.AddWithValue("@ID", id);
            DataSet resultDst = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(resultDst, "OrderProducts");
            }
            
            orderHistoryProductDataGrid.DataSource = resultDst.Tables[0]; 
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
    }`
