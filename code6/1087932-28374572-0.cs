    using (TextFieldParser MyReader = new TextFieldParser(csvPath))
    {
         MyReader.TextFieldType = FieldType.Delimited;
         MyReader.SetDelimiters(",");
         MyReader.HasFieldsEnclosedInQuotes = true;
         string[] currentRow;
         currentRow = MyReader.ReadFields();
         while(!MyReader.EndOfData)
         {
            DataRow row = dt.NewRow();
            currentRow = MyReader.ReadFields();
            for(int i = 0; i < currentRow.Length; i++)
            {
                row[i] = currentRow[i];
            }
            dt.Rows.Add(row); 
         }
     }
