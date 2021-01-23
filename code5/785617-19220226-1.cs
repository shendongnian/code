    if (tableListBox.SelectedIndex == 2)
                {
                    List<object> sendingList = new List<object>();
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        int counter = 0;
                        sendingList.Add(dr.DataBoundItem);
                        
                    } 
                        Form4 form4 = new Form4(sendingList);
                        form4.Show();
                        break; 
                }
