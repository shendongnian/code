    private void txtScanCode_Leave(object sender, EventArgs e)
    {
    string barCode;
    barCode = txtScanCode.Text;
     if (txtScanCode.Text.Length == 12)
     {
        MessageBox.Show(this, "Hey, look!", "A message box!", 
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        FindScanItem(barCode);
        barCode = "";
        txtScanCode.SelectionStart = 0;
        txtScanCode.SelectionLength = txtScanCode.Text.Length;
     }
    }
