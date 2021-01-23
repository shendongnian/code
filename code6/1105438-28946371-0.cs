    if (!int.TryParse(txtDays.Text.Trim(), out days))
    {
       MessageBox.Show("Enter a whole number for days.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
       txtDays.Focus();
       return;
    }
