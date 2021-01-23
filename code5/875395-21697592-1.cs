    DataTable dt = new DataTable();
    foreach (XmlNode xn in doc.Root.Elemets())
    {
      string tagName = xn.Name.LocalName;
      if (!dt.Columns.Contains(tagName))
      {
        dt.Columns.Add(tagName);
      }
    }
    foreach (XmlNode xn in doc.Root.Elements())
    {
      DataRow dr = dt.NewRow();
      dr[xn.Name.LocalName] = xn.value;
      dt.Rows.Add(dr);
    }
