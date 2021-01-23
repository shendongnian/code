            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Sender FROM Messages", conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    comboBoxSender.ValueMember = "Sender";
                    comboBoxSender.DisplayMember = "Sender";
                    comboBoxSender.DataSource = dt;
                }
            }
        
