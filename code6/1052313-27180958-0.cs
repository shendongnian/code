         private void btn1_Click(object sender, EventArgs e)
         {
        
            int regNumber = 0;
            bool regFlag = int.TryParse(txtreg.Text, regNumber)
            
            if(!regFlag)
            {
               MessageBox.Show("Reg textbox doesn't have integer value");
               return;
            }
            
            if(regNumber <= 0)
            {
               MessageBox.Show("Reg textbox has negative or 0 value");
               return;
            }
            
            
            for (int i = 0; i < dgResult1.Columns.Count; i++)
            {
               if (dgResult1.Columns[i].HeaderText != "REGHRS")
                    continue;
                    
               for (int j = 0; j < dgResult1.Rows.Count; j++)
               {
                   string regHrs = dgResult1.Rows[j].Cells["REGHRS"].Value.ToString();
                   int regValue = 0;
                   
                   bool regCheck = int.TryParse(regHrs, out regValue)
                   if(!regCheck || reg < 12)
                       continue;
                           
                   dgResult1.Rows[j].Cells["REGHRS"].Value = txtreg.Text;
                   
                    
                   //till now both converts should be okay.
                   dgResult2.Rows[j].Cells["REGHRS"].Value = Convert.ToInt32(dgResult2.Rows[j].Cells["REGHRS"].Value.ToString()) - Convert.ToInt32(txtreg.Text);
                                
                  dgResult3.Rows[j].Cells["REGHRS"].Value = 0;
                            
               }
                    
               
           }
     
        }
