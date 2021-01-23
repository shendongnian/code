    private void txtSearchID_Keyup(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && !txtSearchID.Text.Equals(string.Empty))
        {
           button_Click(null, null);
        }
    }
