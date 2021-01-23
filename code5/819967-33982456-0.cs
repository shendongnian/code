           try
            {
                if (e.ColumnIndex == 5)
                {
                    string Task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if ( Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataset.Tables["tbl_students"].Rows[rowIndex].Delete();
                            sqlAdapter.Update(dataset, "tbl_students");
                        }
                    }
                    else if(Task == "Insert")
                    {
                        int row = dataGridView1.Rows.Count - 2;
                        DataRow dr = dataset.Tables["tbl_students"].NewRow();
                        dr["id"] = dataGridView1.Rows[row].Cells["id"].Value;
                        dr["name"] = dataGridView1.Rows[row].Cells["name"].Value;
                        dr["address"] = dataGridView1.Rows[row].Cells["address"].Value;
                        dr["phone"] = dataGridView1.Rows[row].Cells["phone"].Value;
                        dr["email"] = dataGridView1.Rows[row].Cells["email"].Value;
                        dataset.Tables["tbl_students"].Rows.Add(dr);
                        dataset.Tables["tbl_students"].Rows.RemoveAt(dataset.Tables["tbl_students"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                        sqlAdapter.Update(dataset, "tbl_students");
                    }
                    else if (Task == "Update")
                    {
                        int r = e.RowIndex;
                        dataset.Tables["tbl_students"].Rows[r]["id"] = dataGridView1.Rows[r].Cells["id"].Value;
                        dataset.Tables["tbl_students"].Rows[r]["name"] = dataGridView1.Rows[r].Cells["name"].Value;
                        dataset.Tables["tbl_students"].Rows[r]["address"] = dataGridView1.Rows[r].Cells["address"].Value;
                        dataset.Tables["tbl_students"].Rows[r]["phone"] = dataGridView1.Rows[r].Cells["phone"].Value;
                        dataset.Tables["tbl_students"].Rows[r]["email"] = dataGridView1.Rows[r].Cells["email"].Value;
                        sqlAdapter.Update(dataset, "tbl_students");
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }           
