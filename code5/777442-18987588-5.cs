    private void textBox_TextChanged(object sender, EventArgs e)
    {
        UpdateText(sender as Control);
    }
    private void UpdateText(Control editingControl)
    {
      System.Diagnostics.Debug.WriteLine(editingControl.Text);
    }
