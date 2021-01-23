    class XmlResult
    {
        public string string1 {get; set;}
        public string string2 {get; set;}
    }
    private XmlResult checkXML(string _title)
    {
        var result = new XmlResult();
        using (XmlReader reader = XmlReader.Create(@"C:\Directory\test.xml"))
        {
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "myElement":
                            string title = reader["title"];
                            if (title == _title)
                            {
                                result.string1 = (reader["publisher"]);
                                result.string2 = (reader["author"]);
                            }
                            break;
                    }
                }
            }
        }
        return result;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var result = checkXML("The Cookbook");
        MessageBox.Show(result.string1); //error: "The name 'string1' does not exist in the current context"
        MessageBox.Show(result.string2); //error: "The name 'string2' does not exist in the current context"
    }
