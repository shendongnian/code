    private int getRecordFieldSize(PropertyInfo recordField,DataRecord dataRecord)
    {
     if (recordField.PropertyType.ToString() == "System.String")
     {
          return recordField.GetValue(dataRecord,null).ToString().Length;
     }
     else
     {
           int bytesOfPropertyType = System.Runtime.InteropServices.Marshal.SizeOf(recordField.PropertyType);
           return bytesOfPropertyType;
     }
}
