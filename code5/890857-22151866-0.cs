    prompt.KeyDown += (sender, e) => ModalForm_KeyDown(sender, e, confirmation);
    
    ...
    
    private static void ModalForm_KeyDown(object sender, KeyEventArgs e, Button confirmation) {
      if (e.KeyData == Keys.Enter) {
        Messagebox.Show("Enter Key Pressed");
        confirmation.PerformClick();
      }
    }
