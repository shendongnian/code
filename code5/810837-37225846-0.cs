    DataTable dt = new DataTable();
        private void B_Click(object sender, EventArgs e)
        {
           
            Button bt = (Button)sender;
            int productId = (int)bt.Tag;
            AddProductDataContext db = new AddProductDataContext();
            decimal Quantity;
            decimal.TryParse(txtCalculator.Text, out Quantity);
            var results = from inv in db.Inventories
                          where inv.RecId == productId
                          select new
                          {
                              inventoryName = inv.InventoryName,
                              Quantity,
                              Total = Quantity * inv.InventoryPrice
                          };
          
          
           
            int rowHandle = gridView1.GetRowHandle(gridView1.DataRowCount);
           
            foreach (var x in results)
            {
                DataRow newRow = dt.NewRow();
                newRow.SetField("inventoryName", x.inventoryName);
                newRow.SetField("Quantity", x.Quantity);
                newRow.SetField("Total", x.Total);
                dt.Rows.Add(newRow);
                             
            }
         
            gridControl1.DataSource = dt;
            
        }              
        private void SaleScreen_Load(object sender, EventArgs e)
        {
            
            dt.Columns.Add("inventoryName");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Total");
        }
