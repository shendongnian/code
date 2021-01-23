    protected void Button1_Click(object sender, EventArgs e)
       {
           DataTable dt = new DataTable();
    
           if (dt.Columns.Count == 0)
           {
               dt.Columns.Add("PayScale", typeof(string));
               dt.Columns.Add("IncrementAmt", typeof(string));
               dt.Columns.Add("Period", typeof(string));
           }
     
           DataRow NewRow = dt.NewRow();
           NewRow[0] = TextBox1.Text;
           NewRow[1] = TextBox2.Text;
           dt.Rows.Add(NewRow); 
           GridView1.DataSource = dt;
           GridViewl.DataBind();
       }
 
