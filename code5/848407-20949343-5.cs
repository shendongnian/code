    foreach (var checkBox in this.Controls.OfType<CheckBox>())
    {
        if (checkBox.Checked)
        {
            int index = int.Parse(checkBox.Name.Substring(7));
            MyFunction(index);
        }
    }
