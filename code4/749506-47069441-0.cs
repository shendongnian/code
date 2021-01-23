     frm.dataGridView2.Rows.Clear();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Value != null)
                            {
                                frm.dataGridView2.Rows.Add();
                                frm.dataGridView2.Rows[i].Cells[0].Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                frm.dataGridView2.Rows[i].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                                frm.dataGridView2.Rows[i].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                                frm.dataGridView2.Rows[i].Cells[3].Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                frm.dataGridView2.Rows[i].Cells[4].Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                                frm.dataGridView2.Rows[i].Cells[5].Value = dataGridView1.Rows[i].Cells[5].Value.ToString();
                            }
                        }
                    }   this 100% works i have used it 
