     bool isValid=false;//declare as class variable
        
    private void rChkBoxB_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
    {
       
     if(!isValid)
     {
     if (Convert.ToInt32(rTxtBoxFormatID.Text) > 256)
        {
            DialogResult dialogresult = MessageBox.Show("B does not support numbering over a number!", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (dialogresult == DialogResult.OK)
            {
                rChkBoxB.Checked = false;
                isValid=true;
            }
             else
            {
            isValid=false;
            }
        }
      }
        else
        {
        isValid=false;
        }
    }
