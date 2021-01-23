    private static void Main(string[] args)
    {
      XmlDocument xd = new XmlDocument();
      xd.Load("C:\\test1.xml");
      XmlNodeList nodelist = xd.SelectNodes("/testcase"); // get all <testcase> nodes
      foreach (XmlNode node in nodelist) // for each <testcase> node
      {
        try
        {
          var name = node.SelectSingleNode("date").InnerText;
          var date = node.Attributes.GetNamedItem("name").Value;
          var sub = node.Attributes.GetNamedItem("subject").Value;
        }
        catch (Exception e)
        {
          MessageBox.Show("Error in reading XML", "xmlError", MessageBoxButtons.OK);
        }
      }
