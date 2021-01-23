    DataTable table = ((DataView)gridView1.DataSource).ToTable();
    int i = 0;
    foreach (XmlNode node in list)
    {
        node.SelectSingleNode("VatAmount").InnerText = Convert.ToString(table.Rows[i]["NewVATAmt"]);
        i++;    
    }
    xdoc.Save(path);
