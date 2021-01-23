     public DataSet GetBrokerDetailspageload()
     {
        MySqlConnection mycon=new MySqlConnection("Your connection string");
        string str = "SELECT sm.BrokerName,st.ID,sm.SalesCode,sm.BillNo,sm.SalesBy,st.ProductName,st.Quantity,st.SalesRate,st.Net‌​Weight,st.Expense,st.Amount,st.VatP,St.VatAmt FROM salesmaster sm INNER JOIN salestransaction st ON sm.SalesCode=st.SalesCode";
        MySqlCommand cmd=new MySqlCommand(str,mycon);
        DataSet ds=new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        da.Fill(ds);
        return ds;
     }
     private void BrokerWiseSalesReport_Load()
     {
         DataSet ds = new DataSet();
         ds = null;
         ds=GetBrokerDetailspageload();
         dataGridView1.DataSource = ds.Tables[0];
     }
