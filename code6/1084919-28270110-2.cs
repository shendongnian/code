    private void txtStudentID_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhitespace(this.txtStudentID.Text))
        {
            sqlDisplayInfo = this.txtStudentID.Text;
        }
        this.txtStudentID.Clear()
    }
