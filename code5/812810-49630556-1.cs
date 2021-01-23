    private void button1_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO product (productid, productname,productdesc,productqty) VALUES (@txtitemid,@txtitemname,@txtitemdesc,@txtitemqty)";
            try
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@txtitemid", txtitemid.Text);
                    command.Parameters.AddWithValue("@txtitemname", txtitemname.Text);
                    command.Parameters.AddWithValue("@txtitemdesc", txtitemdesc.Text);
                    command.Parameters.AddWithValue("@txtitemqty", txtitemqty.Text);
                    con.Open();
                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error");
                    MessageBox.Show("Record...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    loader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
