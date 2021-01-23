        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=logindb;Integrated Security=True");
        string query1 = "select * from tbllogin"; SqlCommand cmd = new SqlCommand(query1); SqlDataReader dr;
        try {
            cn.Open(); dr = cmd.ExecuteReader();
            while (dr.Read())
            { String sname = (string)dr["name"];
            comboBox1.Items.Add(sname);
            }
        }
        catch (Exception e) { MessageBox.Show(e.Message, "An error occurred!"); }
