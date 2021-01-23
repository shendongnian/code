    try
    {
        con.Open();
        string cmdText = @"select distinct product_id, product_name, 
                                 qty, price, tax, discount, total 
                                 from Purchasedetail;
                           select total from Purchase ";
        SqlCommand cmd = new SqlCommand(cmdText, con); 
        // You pass the command and fill the DataSet. 
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        // Now the Dataset contains two tables
        datagrid.DataSource = ds.Tables[0];
        // Of course this retrieves just the total from the first row,
        // I suppose that your second query needs some kind of WHERE condition
        // or some kind of aggregate function like SUM(Total) 
        textBox1.Text = ds.Tables[1].Rows[0][0].ToString();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Exception caught : " + ex.Message);
    } 
    finally
    {
       con.Close();
    }
