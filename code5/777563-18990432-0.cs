         ArrayList files = new ArrayList();
        files.AddRange(System.IO.Directory.GetFiles("c:\\test", "*.xls"));
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        foreach (string i in files)
        {
            comboBox1.Items.Add(i);
        }
        comboBox1.SelectedIndex = 0;
