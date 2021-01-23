    public static Color GetColor(string ChildName, string Attribute)
    {
      Color clr = new Color();
      string v = "";
      XmlDocument doc = new XmlDocument();
      doc.Load("DesignCfg.xml");
      XmlElement formData = (XmlElement)doc.SelectSingleNode("//" + ChildName);
      if (formData != null)
         v = formData.GetAttribute(Attribute);    
      clr = System.Drawing.ColorTranslator.FromHtml(v);
      return clr;
    }
