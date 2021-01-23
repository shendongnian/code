    private void button2_Click(object sender, EventArgs e)
    {
        using(SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\xchoo\Documents\Visual Studio 2012\Projects\WindowsFormsApplication_test2\WindowsFormsApplication_test2\Data.mdf;Integrated Security=True;Connect Timeout=30"))
        //con.Close();
      {
        SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From custInfo where Username='" + USERNAME.Text + "'and Password='" + PASSWORD.Text + "'", con);
        DataTable custInfo=new DataTable();
        //con.Close();
        sda.Fill(custInfo);
        if (custInfo.Rows[0][0].ToString() == "1")
        {
        this.Hide();
        Select_Item select_item = new Select_Item();
        select_item.Show();
        con.Close();
        }
        else
        {
        MessageBox.Show("Please check your Username and Password");
        }
      }
    }
