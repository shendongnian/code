    private void button1_Click(object sender, EventArgs e)
    {
      //document = new XDocument();
       XElement elem = new XElement("table1");
       elem.Add(new XAttribute("TableName", textBox1.Text));
       elem.Add(new XElement("Column1",new XAttribute("Someattribute", somevalue)));
       document.Add(elem);
    }
