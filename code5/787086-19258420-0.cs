    try
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("XMLFile1.xml");
        XmlNode node = doc.SelectSingleNode("/MovieData");
        foreach (XmlNode movie in node.SelectNodes("Movie"))
        {
            if (movie != null)
            {
                movieTypeListBox.Items.Add(movie["Name"].InnerText);
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
