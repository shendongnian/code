    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    
     {
    
     // Check if Enter is pressed //  DGV Cell Edit // dgv1 as DataGrideView
    
     if (keyData == Keys.Enter /* && txtledger.Text != "" */)
     {
        
     try       
    {
        
       if (dgv1.CurrentCell.ColumnIndex == 18 ) 
    
    // 18 is Column Count and focusing length
    
           {                       
    
            dgv1.CurrentCell = dgv1.Rows[dgv1.CurrentRow.Index + 1 ].Cells[1];
            return true;
           }
           else
           {
            SendKeys.Send("{Right}");  //Tab OR Right Key Ur Need
           }
         }
      catch (Exception e)
    
      {                    
    
      dgv1.Rows.Add();
      dgv1.CurrentCell = dgv1.Rows[dgv1.CurrentRow.Index].Cells[1];
                      
      }
    
      return true;
    
      }
    
      return base.ProcessCmdKey(ref msg, keyData);
    
      }
