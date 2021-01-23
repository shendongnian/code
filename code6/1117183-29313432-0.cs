      protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["NIC"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            //INSERT INTO Equiptment VALUES ('2', 'Hammers', '24')
            string query = "INSERT INTO Equiptment VALUES ('"+
                equipAmount.Text +"', '"+
                equipType.Text + "', '" +
                DropDownList1.SelectedValue +"')";
            AddContract.Visible = true;
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
    con.Close();
    //GRID LOAD CODE GOES HERE
    
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand showAll = new SqlCommand("SELECT * FROM Equiptment", con);
    
                SqlDataReader reads = showAll.ExecuteReader();
                GridView1.DataSource = reads;
                GridView1.DataBind();
    }
    
    ///////////////////////
    
            }
            catch {
                con.Close();
            }
        }  
    
    
            }
