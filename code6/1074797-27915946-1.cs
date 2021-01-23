    private void addItem_Click_1(object sender, RoutedEventArgs e)
    {
        try
        {
            XmlDataProvider provider = (XmlDataProvider)this.FindResource("MyData");
            XmlNode elmnt = provider.Document.CreateElement("list");
            elmnt.InnerText = itemTextBox.Text;            
            (provider.Document.ChildNodes[1]).ChildNodes[0].AppendChild(elmnt);
            // Assuming that your XML file is in the same directory as you exe. If not, then 
            // give the right path as parameter to Save
            provider.Document.Save("Product.xml");
        }
        catch (Exception d)
        {
            MessageBox.Show(d.Message);
        }
    }
