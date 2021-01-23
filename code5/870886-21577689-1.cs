    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {    
        XmlNode nodes = xDoc.SelectSingleNode(String.Format("/students/student[id={0}]/data", listBox1.SelectedItem));
        foreach (XmlNode node in nodes.ChildNodes)
        {
             if (node.Attributes["status"].Value == "passed")
                 listBox2.Items.Add(node.Attributes["name"].Value);
        }
    }
