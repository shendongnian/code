    void gkh_KeyDown(object sender, KeyEventArgs e)
    {
      if (ModifierKeys.HasFlag(Keys.Control) && e.KeyCode == System.Windows.Forms.Keys.O)
        cbDrawOverlay.Checked = !cbDrawOverlay.Checked;
    }
