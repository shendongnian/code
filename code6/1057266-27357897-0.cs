    private void cmbcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbcmbstate.Items.Clear();
            con.Open();           
            cmd = new SqlCommand("select sname from state where cname='"+cmbcountry.SelectedItem.ToString()+"'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();      
            while (dr.Read())
            {
                cmbstate.Items.Add(dr[0]);
            } 
            con.Close();
        }
