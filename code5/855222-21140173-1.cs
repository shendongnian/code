    int fc = dataReader.FieldCount;
    while (dtr.Read())
    {
      for (int rt = 0 ; rt < fc ; rt ++)
      {
         if (fc > rt)
         {
             if (!(dtr.IsDBNull(rt)))
             {
                string line = dtr.GetValue(rt).ToString();
                idList.Add(line);
             }
          }
       }
    }
