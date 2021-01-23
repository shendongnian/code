    private void textBoxName_TextChanged(object sender, EventArgs e)
    {
        // name length is maximum 10
        labelName.Color = textBoxName.Text.Length > 10 ? Color.Red : SystemColors.WindowText;
    }
    private void buttonAddProject_Click(object sender, EventArgs e)
    {
        // check name
        string name = textBoxName.Text.Trim()
        if(name.Length == 0 || name.Length > 10)
        {
            labelName.Color = Color.Red;
            textBoxName.Focus();
            textBoxName.SelectAll();
            MessageBox.Show("Name is required. Maximum length is 10.");
            return;
        }
        // check something else
        // ... if check fail - focus, messagebox, return
        // ...
        // insert data
        // ...
        DialogResult = DialogResult.Ok; // close form
    }
