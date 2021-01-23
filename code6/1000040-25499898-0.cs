    private void txtdays_KeyDown(object sender, KeyEventArgs e)
    {
            if (e.KeyCode == Keys.Enter)
            {
                txtnoofPer.Focus();
                txtnoofPer.Select(0, txtnoofPer.Text.Length);
            }
    }
