    public void SaveSettings()
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(location);
    
                XmlNodeList xnList = xml.SelectNodes("/Settings");
    
                XmlNode xn = xml.SelectNodes("/Settings").Item(0);
    
                xn["Height"].InnerText = tb_height.Text;
                xn["Length"].InnerText = tb_lenght.Text;
                xn["Radius"].InnerText = tb_radius.Text;
                xn["Name"].InnerText = tb_name.Text;
    
                xml.Save(location);
            }
