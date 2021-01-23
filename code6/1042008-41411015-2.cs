    private void cmbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (e.KeyChar == 13)
          {
            if (float.Parse(cmbSize.Text.Trim()) == 0)
            {
              MessageBox.Show("Invalid Font Size, it must be Float Number", "Invalid Font Size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              cmbSize.Text = "10";
              return;
            }
            if (cmbSize.Text.Trim() != "")
            {
              Font new1, old1;
              old1 = rtxtBox.SelectionFont;
              new1 = new Font(FontFamily.GenericSansSerif, float.Parse(cmbSize.Text.Trim()), old1.Style);
              rtxtBox.SelectionFont = new1;
            }
            rtxtBox.Focus();
          }
        }
