    private void addItem_Click_1(object sender, RoutedEventArgs e)
    {
        try
        {
            XmlDataProvider provider = (XmlDataProvider)this.FindResource("MyData");
            XmlNode elmnt = provider.Document.CreateElement("list");
            elmnt.InnerText = itemTextBox.Text;
            provider.Document.ChildNodes[1].AppendChild(elmnt);
        }
        catch (Exception d)
        {
            MessageBox.Show(d.Message);
        }
    }
