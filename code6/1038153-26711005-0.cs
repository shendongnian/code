    if (headerText.StartsWith(tableHeaders[j]))
    {
        // get file name
        string filename = getFilename(targetDir, file, j + 1);
    
        //Create a new document
         Document newDocument = application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
    
        var copyFrom = table.Cell(row + 1, 1).Range;
        int start = newDocument.Content.End - 1;
        int end = newDocument.Content.End;
        var copyTo = newDocument.Range(start, end);
    
        copyFrom.MoveEnd(WdUnits.wdCharacter, -1);
        copyTo.FormattedText = copyFrom.FormattedText;
    
        // save file
        newDocument.SaveAs2(filename);
        newDocument.Close();
    }
