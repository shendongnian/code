    private void tbTableName_TextChanged(object sender, EventArgs e)
    {
        string name = Regex.Replace(tbTableName.Text, @"^\d+|\W", string.Empty);
        btnConvert.Enabled = name.Length > 0;
        tbTableName.Text = name;
    }
