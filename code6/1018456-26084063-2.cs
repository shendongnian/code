    public void showout2()
            {
                object[] newRow = new object[14];
                try
                {
    
                    newRow[0] = "test";
                    newRow[1] = "test";
                    newRow[2] = "test";
                    newRow[3] = "test";
                    newRow[4] = "test";
                    newRow[5] = "test";
                    newRow[6] = "test";
                    //...
                    dataGridView1.Rows.Add(newRow);
    
                    if (MessageBox.Show("تريد أدخال سجل أخر؟", "Some Title", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //clear data here or do what you want..
                    }
    
                }
                catch (Exception ex)
                {
    
                }
            }
