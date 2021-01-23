    public static string toJson(this DataTable dataTable)
    {
        string[] StrDc = new string[dataTable.Columns.Count];
        string HeadStr = string.Empty;
        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            StrDc[i] = dataTable.Columns[i].Caption;
            HeadStr += "\"" + StrDc[i] + "\" : \"" + StrDc[i] + i.ToString() + "¾" + "\",";
        }
        HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);
        StringBuilder Sb = new StringBuilder();
        Sb.Append("{\"" + dataTable.TableName + "\" : [");
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            string TempStr = HeadStr;
            Sb.Append("{");
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                TempStr = TempStr.Replace(dataTable.Columns[j] + j.ToString() + "¾", dataTable.Rows[i][j].ToString());
            }
            Sb.Append(TempStr + "},");
        }
        Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
        Sb.Append("]}");
        return Sb.ToString();
    }
