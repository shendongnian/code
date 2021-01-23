    public static Color GetColor(string ChildName, string Attribute) 
    {
     Color clr = new Color(); string v = ""; 
     XmlTextReader reader = new XmlTextReader("DesignCfg.xml"); 
     XmlDocument doc = new XmlDocument(); 
     XmlNode node = doc.ReadNode(reader); 
    foreach (XmlNode chldNode in node.ChildNodes) 
    { 
       if (chldNode.Name == ChildName) 
          v = chldNode.Attributes["" + Attribute + ""].Value; 
    } 
    clr = System.Drawing.ColorTranslator.FromHtml(v);
    return clr; 
    }
