    private void fillcode()
    {
        try
        {
           SqlConnection con = new SqlConnection("Data Source=ANISH;Initial Catalog=HM;Integrated Security=True");
                con.Open();
            string s = "select max(CustomerId) as Id from CustomerDetails";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
            int i = Convert.ToInt16(dr["Id"].ToString());
            sid.Text = (i + 1).ToString();
            }
            else
            {
             sid.Text = "1"
            } 
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
