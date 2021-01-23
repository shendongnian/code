    try
                {
                    foreach (DataGridViewRow r in this.dataGridView1.Rows)
                    {
                        if (r.Cells[0].Value != null)
                        {
                            if ((r.Cells[0].Value).ToString().StartsWith(this.textBox1.Text.Trim()) && textBox1.Text.Trim().Length > 0)
                            { 
                                this.dataGridView1.Rows[r.Index].Visible = false;
                            }
                            else
                            {
                                this.dataGridView1.Rows[r.Index].Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
