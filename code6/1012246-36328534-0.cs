     private void grdServices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
    
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "img";
                img.HeaderText = "CheckOut";
                img.ReadOnly = true;
                int number_of_rows = grdServices.RowCount;
                if (number_of_rows > 0)
                {
                    grdServices.Columns.Add(img);
    
                    for (int i = 0; i < number_of_rows; i++)
                    {
    
                        if (bool.Parse(grdServices.Rows[i].Cells[27].Value.ToString()) == true)
                        {
                            grdServices.Rows[i].Cells["img"].Value = (System.Drawing.Image)Properties.Resources.yes;
                        }
                        else
                        {
                            grdServices.Rows[i].Cells["img"].Value = (System.Drawing.Image)Properties.Resources.no;
                        }
    
                    }
                }
    
            }
        }
