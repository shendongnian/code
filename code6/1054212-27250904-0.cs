     foreach (int rowval in rowscol)
    {
       bool hasNonNullValue = false;
       Dictionary<string, object> Data = new Dictionary<string, object>();
       foreach (Contracts.CommonDataField field in finalColumns)
       {
       var valList = record.CommonDataValues.FirstOrDefault(row => row.RowID == rowval && row.FieldName == field.FieldName);
       if (valList != null)
       {
         string value = valList.RecordFieldData;
         Data.Add(field.FieldName, value);
         if (value != null) {
            hasNonNullValue = true;
         }
       }
      }
      if (hasNonNullValue) {
        finaldata.Add(Data);
      } 
    }
