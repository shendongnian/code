    DataTable dt = new DataTable();
    foreach (XmlNode xn in doc.Root.Elemets())
    {
      string tagName = xn.LocalName;
      if (!dt.Columns.Contains(tagName))
      {
        dt.Columns.Add(tagName);
      }
    }
    foreach (XmlNode xn in doc.Root.Elements())
    {
      DataRow dr = dt.NewRow();
      string value = xn.Value;
      dr[tagName] = value;
    }
