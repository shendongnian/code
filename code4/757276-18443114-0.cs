    XmlDocument xd = new XmlDocument();
    xd.Load("test.xml");
    XmlNodeList nodelist = xd.SelectNodes("/testcase"); // get all <testcase> nodes
    foreach (XmlNode node in nodelist) // for each <testcase> node
    {
        try
        {                    
              string name = node.SelectSingleNode("name").InnerText;
              string date = node.SelectSingleNode("date").InnerText;
              string sub = node.SelectSingleNode("subject").InnerText;
        }
        catch (Exception ex)
        {
              MessageBox.Show("Error in reading XML", "xmlError", MessageBoxButtons.OK);
        }
    }
