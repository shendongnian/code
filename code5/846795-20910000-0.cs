    try
                {
                    MySqlCommand cmdc = new MySqlCommand("insert into mov (folio  ,clave  ,descr  ,total, timo) VALUES ('" + textBox1.Text + "'  ,'" + comboBox1.Text + "'  ,'" + textBox3.Text + "'  ," + r1 + ",'S');", conn);
                    MySqlDataAdapter dataadapc = new MySqlDataAdapter(cmdc);
                    System.Data.DataTable datatabc = new System.Data.DataTable();
                    dataadapc.Fill(datatabc);
                    foreach (DataRow row in datatabc.Rows)
                    {
                        string rows = string.Format("{0}", row.ItemArray[0]);
                        aux = rows;
                    }
                    try
                    {
                        MySqlCommand command = new MySqlCommand("update inventario SET can = can - " + numericUpDown1.Value + " WHERE cla = '" + comboBox1.Text + "';", conn);
                        command.ExecuteNonQuery();
                        j++;
  
                        MySqlCommand command = new MySqlCommand("update inventario SET lin = 'CMI', dias = 0 WHERE cla = '" + comboBox1.Text + "';", conn);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: No se puede modificar el inventario.");
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se puede modificar el inventario.");
                    MessageBox.Show(ex.Message);
                }
      
            }
