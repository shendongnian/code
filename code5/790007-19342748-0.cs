    objAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    SqlCommandBuilder sqlCmdBuilder = new SqlCommandBuilder(objAdapter);
    objAdapter.Fill(objTable);
    foreach(DataRow objRow in objTable.Rows)
    {
    byte[] objData = (byte[])objRow["img"];
    var firstNBytes = objData.Take(4);
    Byte[] threeBytes = new Byte[] { objData[0], objData[1], objData[2], objData[3] };
    var bytesToCompare = Encoding.Unicode.GetBytes("0x25");
    bool equal = firstNBytes.SequenceEqual(bytesToCompare);
    string hex = BitConverter.ToString(threeBytes);
    hex.Replace("-", "");
    
    
    string strFileToSave = Guid.NewGuid();
    
    if (hex == "25-50-44-46")
    {
        strFileToSave += ".pdf";
    }
    else
    {
        strFileToSave += ".jpg";
    }
    
    FileStream objFileStream = new FileStream(strFileToSave, FileMode.Create, FileAccess.Write);
    objFileStream.Write(objData, 0, objData.Length);
    objFileStream.Close();
    }
