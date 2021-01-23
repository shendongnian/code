    private void cmbUserLogin_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && cmbUserLogin.DroppedDown)
        {
            if (cmbUserLogin.Items.Count > 0)
            {
                int currentItem = cmbUserLogin.SelectedIndex;
                if (currentItem >= 0)
                {
                    cmbUserLogin.SelectedIndex = -1;
                    if (cmbUserLogin.Items.Count == 1)
                    {
                        cmbUserLogin.DroppedDown = false;
                        cmbUserLogin.Items.Clear();
                        cmbUserLogin.Text = null;
                    }
                    else
                    {
                        cmbUserLogin.Items.RemoveAt(currentItem);
                    }
                    cmbUserLogin.SelectedIndex = -1;
                }
            }
            e.Handled = true;
        }
    }
