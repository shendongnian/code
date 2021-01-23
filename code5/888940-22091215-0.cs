    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var item in checkedListBox1.CheckedItems)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=email_client;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select * from address_book where name='{0}'", item), con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                stringBuilder.Append(Convert.ToString(dr["id"] + ","));
            }
            dr.Close();
        }
        textBox1.Text = stringBuilder.ToString().TrimEnd(',');
    }
