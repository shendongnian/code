              int id =Convert.ToInt32( textBox1.Text);
                string query = "SELECT * FROM ngo.inser WHERE ID LIKE '%" + id + "%'";
                command = new MySqlCommand(query, connection);
                adapter = new MySqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                
                dataGridView1.DataSource = table;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
