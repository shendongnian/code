    var modDt = new DataTable();
    modDt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
    modDt.Columns.Add(new DataColumn("Type", typeof(int))); 
    var document = XDocument.Load("doc.xml");
    XNamespace nsSys = "http://www.cdisc.org/ns/odm/v1.3";
    //Get ItemData attributes group by the itemGroupData
    var itemGroupDatas =
        document.Descendants(XName.Get("ItemGroupData", nsSys.NamespaceName))
                .Elements(XName.Get("ItemData", nsSys.NamespaceName))
                .Select(x => new
                    {
                        itemOID = x.Attribute(XName.Get("ItemOID")),
                        value = x.Attribute(XName.Get("Value"))
                    })
                .Where(
                    x =>
                    x.itemOID != null && x.value != null &&
                    (x.itemOID.Value == "I_TABLE_MODAL_DATE_TABLE" ||
                     x.itemOID.Value == "I_TABLE_MODAL_TYPE_TABLE"))
                .GroupBy(x => x.itemOID.Parent.Parent, x => x);
    foreach (var itemGroupData in itemGroupDatas)
    {
        // record per each group
        var row = modDt.NewRow();
        foreach (var itemData in itemGroupData)
        {
            if (itemData.itemOID.Value == "I_TABLE_MODAL_DATE_TABLE")
            {
                DateTime date;
                if (DateTime.TryParse(itemData.value.Value, out date))
                {
                    row["Date"] = date;
                }
            }
            if (itemData.itemOID.Value == "I_TABLE_MODAL_TYPE_TABLE")
            {
                int type;
                if (int.TryParse(itemData.value.Value, out type))
                {
                    row["Type"] = type;
                }
            }
        }
        modDt.Rows.Add(row);
    }
    Console.ReadLine();
