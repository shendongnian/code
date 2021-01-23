    private void button1_Click(object sender, EventArgs e)
    {
        var xDoc = XDocument.Load(XML_Path)
        string keep = "EmpId,Sex,Address,Zip";
        string[] strArr = keep.Split(',');
        var nodesToDelete = xDoc.Root.Descendants("Employee")
            .SelectMany(e => e.Descendants()
                              .Where(a => !strArr.Contains(a.Name.ToString())));
        foreach (var node in nodesToDelete.ToList())
            node.Remove();
        richTextBox1.Text = xDoc.ToString();
    }
