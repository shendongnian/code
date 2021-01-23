     private void createLabelFromSql()
        {
            try
            {
                string query = "SELECT * FROM [schema] WHERE id=@id";
                SqlCommand com = new SqlCommand(query, spojeni);
                com.Parameters.AddWithValue("@id", idSch);
                spojeni.Open();
                SqlDataReader precti = com.ExecuteReader();
                while (precti.Read())
                {
                    createLabelCmd((int)precti["x"], (int)precti["y"]);
                }
                spojeni.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally { spojeni.Close(); }
        }
        private void createLabelCmd(int x, int y)
        {
            var newLabel = new Label();
            newLabel.Location = new Point(y, x);
            newLabel.Font = new Font(newLabel.Font.FontFamily.Name, 9, FontStyle.Bold);
            newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            newLabel.MouseMove += new MouseEventHandler(this.MyControl_MouseMove);
            newLabel.MouseDown += new MouseEventHandler(this.MyControl_MouseDown);
            panel1.Controls.Add(newLabel);
        }
        private void SaveAllLabels()
        {
            spojeni.Open();
            //delete all data
            SqlCommand delCmd = new SqlCommand("DELETE FROM  [schema] WHERE id=@id", spojeni);
            delCmd.Parameters.AddWithValue("@id", idSch);
            delCmd.ExecuteNonQuery();
            //create new data for current state
            string query = "INSERT INTO [schema] VALUES (@x, @y, @id)";
            SqlCommand cmd = new SqlCommand(query, spojeni);
            cmd.Parameters.Add("@x", SqlDbType.Int);
            cmd.Parameters.Add("@y", SqlDbType.Int);
            cmd.Parameters.AddWithValue("@id", idSch);
            foreach (Control item in panel1.Controls)
            {
                if (item is Label)
                {
                    cmd.Parameters["@x"].Value = item.Location.X;
                    cmd.Parameters["@y"].Value = item.Location.Y;
                    cmd.ExecuteNonQuery();
                }
            }
            spojeni.Close();
        }
