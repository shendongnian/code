    String st = "INSERT INTO supplier(supplier_id, supplier_name)VALUES( '"+ textBox1.Text + "', '" + textBox2.Text + "')";
            SqlCommand sqlcom = new SqlCommand(st, myConnection);
            try
            {
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("insert successful");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
