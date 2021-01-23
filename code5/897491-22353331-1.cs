         protected void ShowAllButton_Click(object sender, EventArgs e)
           {
             //get data from sql query..
               SqlDataAdapter sda = new SqlDataAdapter(cmd);
               DataSet datas = new DataSet();
               sda.Fill(datas);
               GridView1.DataSource = ds.Tables[0];
               GridView1.DataBind(); //GRIDVIEW CONTAINS 300+rows
               con.Close();
               modalHouse.show();
           }
