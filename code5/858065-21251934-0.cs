    XmlDocument xworkload = new XmlDocument();
    
    private void Button_Click(object sender, RoutedEventArgs e)
            {
     xworkload.Load(path to xml);
     string xmlcontents = xworkload.InnerXml;
    
                    XmlNodeList quantities = xworkload.SelectNodes("//PowerSupply/Item/quantity");
                    int sum = 0;
                    foreach (XmlNode quantity in quantities)
                    {
                        sum = sum + Int32.Parse(quantity.InnerText);                    
                    }
        MessageBox.Show("The power supply count is " + sum.ToString());
     }    
