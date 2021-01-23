    private void cmbUserLogin_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && cmbUserLogin.DroppedDown)
        {
            if (cmbUserLogin.Items.Count > 0)
            {
                int currentItem = cmbUserLogin.SelectedIndex;
                if (currentItem >= 0)
                {
                    // todo
                    if (cmbUserLogin.Items.Count == 1)
                        cmbUserLogin.DroppedDown = false;
                    cmbUserLogin.Items.RemoveAt(currentItem);
                }
            }
            e.Handled = true;
        }
    }
