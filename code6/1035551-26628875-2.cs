    foreach (DataColumn col in dSet.Tables[0].Columns)
                {
                    if (notNull)
                    {
                        str += row[col].ToString();
                    }
                    else if (!notNull)
                    {
                        str += "";
                    }
                }
