    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(filepath);
    XmlElement root = xmlDoc.DocumentElement;
    XmlNode node = root.SelectSingleNode("SurveySetting");
    if (node != null && node.Attributes.Count > 0 && node.Attributes["IsServeyOn"] != null && !string.IsNullOrEmpty(node.Attributes["IsServeyOn"].Value))
      {
            RadiobuttonSurverysetting.SelectedValue = node.Attributes["IsServeyOn"].Value;
      }
