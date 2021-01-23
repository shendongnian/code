    foreach (XmlNode n in result.ChildNodes)
    {
        DataRow row = leads.NewRow();
        row["ID1"] = n["Id1"].InnerText;
        row["ID2"] = n["Id2"].InnerText;
        row["CREATEDDATE"] = n["DateAdded"].InnerText;
        leads.Rows.Add(row);
        row.SetModified();
    }
