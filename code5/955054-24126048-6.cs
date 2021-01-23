    Dictionary<string, Range> dictionary = new Dictionary<string, Range>();
    foreach (Worksheet sheet in wb.Sheets) {
        foreach (Range range in sheet.Names) {
            dictionary.Add( range.Name, Range );
            //use here range var
            var cells= range.Cells;
         }
    }
