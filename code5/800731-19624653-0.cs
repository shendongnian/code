    private void button1_Click(object sender, EventArgs e)
    {
        var xDoc = XDocument.Load(XML_Path)
        var nodesToDelete = xDoc.Root.Descendants("Employee")
                                .Select(e => new
                                     { Name = e.Element("Name"), 
                                       Country = e.Element("Address").Element("Country") 
                                     })
                                .ToList();
        foreach (var node in nodesToDelete.ToList())
        {
            node.Name.Remove();
            node.Country.Remove();
        }
        richTextBox1.Text = xDoc.ToString();
    }
