    private void txtStudentID_TextChanged(object sender, EventArgs e)
    {
        string a = txtStudentID.Text;
        if (!string.IsNullOrWhitespace(a))
        {
            sqlDisplayInfo = a;
        }
        txtStudentID.Text.Clear()
    }
