    string Name = EscapeSpecialCharacters(drData["Name"].ToString());
    DataRow[] newDr = this.ds.Tables["TableName"].Select("Name = '" + Name  + "'");
    private static string EscapeSpecialCharacters(string Name)
    {
       StringBuilder sb = new StringBuilder(Name.Length);
       for (int i = 0; i < Name.Length; i++)
       {
            char c = Name[i];
            switch (c)
            {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[" + c + "]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    default:
                        sb.Append(c);
                        break;
            }
       }
       return sb.ToString();
    }
