    foreach (var checkBox in this.Controls.OfType<CheckBox>().Where(c => c.Checked))
    {
        int? index = checkBox.Tag as int;
        if (index.HasValue)
        {
            MyFunction(index.Value);
        }
    }
