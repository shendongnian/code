            String id = idTextBox.Text;
            OleDbCommand command = new OleDbCommand("Select *from User Where [ID]= "+ id +" ");
            command.Connection = conn;
            OleDbDataReader dr = null;
            conn.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                name.Text = (dr["Name"].ToString());
                lName.Text = (dr["LastName"].ToString());
                uName.Text = (dr["UserName"].ToString());
                pass.Text = (dr["Password"].ToString());
                address.Text = (dr["Address"].ToString());  
                email.Text = (dr["Email"].ToString());
                id.Text = (dr["ID"].ToString());
            }
            conn.Close();
