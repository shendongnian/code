     List<string> columns = excelobj.GetCSVColumnNames(excelUploadedFullPath);
                    //  sw.WriteLine("Col1=Phone Text Width 10");
    for (int i = 0; i < columns.Count; i++)
    {
       sw.WriteLine("Col" + (i + 1) + "=" + columns[i].Replace(" ", "_") + " Text Width 100");
    }
    sw.Flush();
    sw.Close();
