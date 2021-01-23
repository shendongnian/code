    private void button1_Click(object sender, EventArgs e)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)row.Cells[0];
    
                    if (ch1.Value == null)
                        ch1.Value = false;
                    switch (ch1.Value.ToString())
                    {
                        case "True":
                            ch1.Value = false;
                            break;
                        case "False":
                            ch1.Value = true;
                            break;
                    }
                }
            }
    
    private void button2_Click(object sender, EventArgs e)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)row.Cells[0];
    
                    if (ch1.Value == null)
                        ch1.Value = false;
                    switch (ch1.Value.ToString())
                    {
                        case "True":
                            ch1.Value = true;
                            break;
                        case "False":
                            ch1.Value = false;
                            break;
                    }
                    var val = row.Cells[1].Value;
                    if (ch1.Value.ToString() == "True") continue;
                    MessageBox.Show("1");
                }
            }
