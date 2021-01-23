    var columns = new Dictionary<string, string>();
    for (int i = 1; i <= 10; i++) columns.Add("Address" + i, string.Empty);
    var textBoxes = Controls.Find("txt_Address", true).Where(t => t is TextBox).ToList();
    columns.ToList().ForEach(c =>
    {
        var index = c.Key.Replace("Address", string.Empty);
        var textBox = textBoxes.FirstOrDefault(t => index.Equals(t.Name.Replace("txt_Address", string.Empty)));
        if (textBox != null) columns[c.Key] = textBox.Text;
    });
