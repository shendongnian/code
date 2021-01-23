    IRfcTable fieldsTable = fn.GetTable("FIELDS");
    fieldsTable.Append();
    fieldsTable.SetValue("FIELDNAME", "VBELN"); //Sales Document
    fieldsTable.Append();
    fieldsTable.SetValue("FIELDNAME", "POSNR"); // Sales Document Item
    fieldsTable.Append();
    fieldsTable.SetValue("FIELDNAME", "MATNR"); // Material number
