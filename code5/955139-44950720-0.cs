    private DialogResult ShowMessageBox(string p_text, string p_caption, MessageBoxButtons p_buttons, MessageBoxIcon p_icon) {
        bool detached = false;
        try {                
            // detach events
            MyGrid.CellFormatting -= MyGrid_CellFormatting;        
            detached = true;
            // show the message box
            return MessageBox.Show(p_text, p_caption, p_buttons, p_icon);
        }
        catch(Exception ex) {
            throw ex;
        }
        finally {
            if(detached) {
                // reattach
                MyGrid.CellFormatting += MyGrid_CellFormatting;            
            }        
            MyGrid.Invalidate();        
        }         
    }
