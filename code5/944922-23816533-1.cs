				var idsToRemove = new List<int>();
				var rowsToRemove = new List<int>();
				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					DataGridViewRow delrow = dataGridView1.Rows[i];
					if (delrow.Selected == true)
					{
						try
						{
							//com.CommandText = "DELETE  FROM Products WHERE ProductID=" + dataGridView1.Rows[i].Cells[0].Value + "";
							//com.Connection = con;
							//int count = com.ExecuteNonQuery();
							idsToRemove.add(dataGridView1.Rows[i].Cells[0].Value);
						}
						catch (Exception ex) { MessageBox.Show(ex.ToString()); }
						//dataGridView1.Rows.RemoveAt(i);
						//^this changes the list length throws things off
                                                rowsToRemove.Add(i);
					}
				}
				
				con.Open();
				com.CommandText = "DELETE  FROM Products WHERE ProductID in(" + string.join(',', idsToRemove.ToArray() + ")";
				con.Close();
				
				//now rebind your grid so it has the right data
                                // or for each row to remove dataGridView1.Rows.RemoveAt(arow)
