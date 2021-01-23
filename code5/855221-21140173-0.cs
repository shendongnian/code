    int fc = dataReader.FieldCount; /* probably move this to outside the Read() call  */
    if (fc > rt)
    {
    if (!(dtr.IsDBNull(rt)))
      {
           string line = dtr.GetValue(rt).ToString();
           idList.Add(line);
                       
      }
    }
    rt++;
