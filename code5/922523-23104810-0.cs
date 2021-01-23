      void richTextBox1_KeyDown(object sender, KeyEventArgs e)
      {
          if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.Z)
            {
                 MessageBox.Show("Ctrl + Z is Pressed");
            }
      }
