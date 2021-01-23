    var sw = new StreamWriter(@"output.csv");
    var csvWriter = new CsvHelper.CsvWriter(sw);
    int lbxCount = lbx.Items.Count;
    int ptrCount = ptr.Items.Count;
    for (int i = 0; i < Math.Max(lbx.Items.Count, ptr.Items.Count); i++)
    {
        object lbxValue = lbxCount > i ? lbx.Items[i] : String.Empty;
        object ptrValue = ptrCount > i ? ptr.Items[i] : String.Empty;
        csvWriter.WriteField(lbxValue);
        csvWriter.WriteField(ptrValue);
        csvWriter.NextRecord();
    }
    sw.Flush();
    sw.Close();
