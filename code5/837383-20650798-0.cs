     foreach (DataRow row in dataset.Tables[0].Rows)
            {
                if (row["USER_COMMENT"] is System.DBNull)
                {
                    row["USER_COMMENT"] = "NO DATA";
                    Console.WriteLine("In if");
                }
                else
                {
                    Console.WriteLine("out if");
                }
            }
