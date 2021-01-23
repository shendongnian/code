    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
      // If user (not system!) wants to close the form
      // but (s)he answered "no", do not close the form
      if (e.CloseReason == CloseReason.UserClosing)
        e.Cancel = MessageBox.Show(@"Are You Sure about clothing the form", 
                                   Application.ProductName, 
                                   MessageBoxButtons.YesNo) == DialogResult.No;
    }
