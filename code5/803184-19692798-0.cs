    protected override void OnFormClosing(FormClosingEventArgs e) {
      if (e.CloseReason == CloseReason.UserClosing) {        
        if (MessageBox.Show("Do you want to close?", 
                            "Confirm", 
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) {
          e.Cancel = true;
        }
      }
      base.OnFormClosing(e);
    }
