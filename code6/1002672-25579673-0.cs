     if (found == false)
                    {
                        if (i > 0 && ctot25 != 0 || ctot50 != 0 || ctot100 != 0)
                        {
                            //Somthethin
    
                            Label lbl_Name = new Label { Location = new Point(50, 50), Text = (dataGridView1.Rows[i].Cells[1].Value).ToString() };
                             this.Controls.Add(lbl_Name);
                            
                             //The rest of the codes
                            
                        }
                    }
