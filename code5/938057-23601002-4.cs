    foreach (var columnName in lines.First()
                 .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
    {
        if (columnName == "Gender")
        {
            var dgc = new DataGridViewComboBoxColumn() { HeaderText = "Gender" };
            dgc.Items.AddRange(
                new KeyValuePair<int, string>(1, "Male"),
                new KeyValuePair<int, string>(2, "Female"));
            dgc.ValueMember = "Key";
            dgc.DisplayMember = "Value";
            dataGridView1.Columns.Add(dgc);
            continue;
        }
        dataGridView1.Columns.Add(columnName, columnName);
    }
