    int index = 1; 
    foreach (var checkBox in this.Controls.OfType<CheckBox>())
    {
        if (checkBox.Checked)
        {
            MyFunction(index);
        }
        index++;
    }
