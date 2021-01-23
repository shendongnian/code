        protected void Button1_Click1(object sender, EventArgs e)
        {
            string commandText = "INSERT INTO " + drbdlSection.SelectedItem.ToString() + 
                                 "(Title,Contect) VALUES (@title, @edit)"
            using(SqlConnection con = prepareConnection())
            using(SqlCommand command = new SqlCommand(commandText, con))
            {
                command.Parameters.AddWithValue("@title", titleTextBox.Text);
                command.Parameters.AddWithValue("@edit", CKEditor1.Text);
                command.ExecuteNonQuery();
            } 
        }
        protected SqlConnection prepareConnection()
        {
            SqlConnection con = new SqlConnection(......);
            con.Open();
            return con;
        }
