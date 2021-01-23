    private void txtbClassNameA_KeyDown_1(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) { } // does nothing, just evaluates the condition
        btnClassNameA.Text = txtbClassNameA.Text;
        txtbClassNameA.Visible = false;
    }
