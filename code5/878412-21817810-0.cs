     private void btnSave_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < gridItem.Items.Count - 1; i++)
                {
                    DataRowView drv = gridItem.Items[i] as DataRowView;
    				
                    string a = drv[3].ToString();                
                    dt = db.MySelect("select ItemNumbers from TotalItems where ItemName='" + a + "'");
                    comboBox1.ItemsSource = dt.DefaultView;
                    comboBox1.DisplayMemberPath = "ItemNumbers";
                    comboBox1.SelectedValuePath = "ItemNumbers";
    				
                    int b = 0;
                    b = Convert.ToInt32(drv[4]);
                    int c, count;
                    int.TryParse(comboBox1.Text, out c);
                    count = c - b;                
                    db.DoCommand("update TotalItems set ItemNumbers='" + count.ToString() + "' where ItemName='" + a + "'");
                }
                MessageBox.Show("Inserted");
            }
