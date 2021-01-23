    foreach (int rowval in rowscol)
    {
       Dictionary<string, object> Data = new Dictionary<string, object>();
       bool empty = true;
       foreach (Contracts.CommonDataField field in finalColumns)
       {
           var valList = record.CommonDataValues.FirstOrDefault(row => row.RowID == rowval && row.FieldName == field.FieldName);
           if (valList != null)
           {
               string value = valList.RecordFieldData;
               Data.Add(field.FieldName, value);
               if(!String.IsNullOrEmpty(value)) empty = false;
           }
       }
       if (!empty) finaldata.Add(Data);
    }
