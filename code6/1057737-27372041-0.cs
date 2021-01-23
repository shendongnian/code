         StringBuilder sqlColumns = new StringBuilder();
            foreach (DataRowView row in dv)
            {
                // code to add columns to create table statement
                switch (row["DWFieldDataType"].ToString())
                {
                    case "varchar":
                        sqlColumns.AppendLine(row["DWFieldName"] + " varchar(" + row["DWFieldLength"] + ") NULL,");
                        break;
                    case "Date":
                        sqlColumns.AppendLine(row["DWFieldName"] + " Date NULL,");
                        break;
                    case "numeric":
                        sqlColumns.AppendLine(row["DWFieldName"] + " numeric(" + row["DWFieldLength"] + "," + row["DWFieldScale"] + ") NULL,");
                        break;
