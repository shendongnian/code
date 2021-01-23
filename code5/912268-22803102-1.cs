    if (dt != null)
    {
        foreach (DataRow row in dt.Tables[0].Rows)
        {
            foreach (DataColumn col in dt.Tables[0].Columns)
            {
                string type = col.DataType.Name;
                if (row.IsNull(col))
                {
                    if (type == "String") //for string values
                    {
                        row.SetField(col, "-");
                    }
                    else // for integer
                    {
                        row.SetField(col, 0);
                    }
                }
            }
        }
    }
