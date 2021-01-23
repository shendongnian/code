     foreach (DataGridViewRow row in dgvWebData.Rows)
                {
                   
                    if (Convert.ToString(row.Cells["IssuerName"].Value) != Convert.ToString(row.Cells["SearchTermUsed"].Value))
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                       
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    
                }
