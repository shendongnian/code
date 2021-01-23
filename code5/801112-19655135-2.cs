    dataGridView1.Columns.Add("a", "Image");
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[8].ToString() == "1")
                    {
                        dataGridView1.Rows[i].Cells["a"] = new DataGridViewImageCell();
                        dataGridView1.Rows[i].Cells["a"].Value = (System.Drawing.Image)Properties.Resources.Config;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["a"].Value = (System.Drawing.Image)Properties.Resources.Config;
    
                    }
                }
