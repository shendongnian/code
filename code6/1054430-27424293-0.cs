    private void txtScanCode_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
       {
           
           if (e.KeyCode == Keys.Enter)
           {
               e.SuppressKeyPress = true;
               barCode = txtScanCode.Text.Trim().ToString();
               if (!doDataStuff) //This boolean is instantiated as false
               {
                   if (txtScanCode.Text.Length == 12)
                   {
                       doDataStuff = true; //boolean tells the app go run data functions.
                       MessageBox.Show(this, "Pop up worked!", "Cool!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       getData(barCode); //Data methods performed on the barcode
                       barCode = "";
                       txtScanCode.Focus();
                       txtScanCode.SelectionStart = 0;
                       txtScanCode.SelectionLength = txtScanCode.Text.Length;
                   }
               }
           }
       }
