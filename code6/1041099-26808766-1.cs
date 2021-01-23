    private void txtbClassNameA_KeyDown_1(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
           btnClassNameA.Text = txtbClassNameA.Text;
           txtbClassNameA.Visible = false;
        }
    }
