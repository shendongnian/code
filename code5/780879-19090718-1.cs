    using (var DataReader = DoQuery(""))
    {
        if (DataReader.HasRows)
        {
            ReaderResult.Clear();
            while (DataReader.Read())
            {
                for (int i = 0; i < DataReader.FieldCount; i++)
                {
                    if (DataReader.IsDBNull(i))
                    {
                        string CaseNull = "";
                        ReaderResult.Add(CaseNull);
                    }
                    else
                    {
                        //put results in LIST<>
                        ReaderResult.Add(DataReader.GetString(i));
                    }
                }
            }
        }
    }
