     private bool IsPressedCtrlV = false;
     private void textBox1_KeyDown(object sender, KeyEventArgs e)
     {
         // You have access to modifiers in here, so you can detect the Control key
         IsPressedCtrlV = (e.Modifiers == Keys.Control && e.KeyCode == Keys.V);
     }
     private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
     {
         if (IsPressedCtrlV)
         {
             // When the key "press" is complete, handle ctrl-v however you want
             e.Handled = true;
             MessageBox.Show("No pasting allowed!");
         }
     }
