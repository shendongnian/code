    if (result !=false )
    {     
         DataTable dt =  (DataTable)this.dataGridView1.DataSource;
         DataRow row = dt.NewRow();
         row.ItemsArray = new Object[]
         {
             textBox1.Text, 
             textBox2.Text,
             CardNumber.Text,
             ScanID.Text, 
             "OUT",
             DateTime.Now
         };
         dt.Rows.Add(row);                                      
     }
