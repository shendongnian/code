    List<string> keywordList = new List<string>();
    foreach (DataRow row in keyWordTable.Rows)
    {
         keywordList.Add(row["KeyWord"].ToString());
    }
    DataTable finalFilteredTable = mainDataTable.Clone();
    bool check = false;
    foreach (DataRow row in mainDataTable.Rows)
    {
         check = false;
         string description = row["Description"].ToString();
         foreach (string s in keywordList)
         {
              if (description.Contains(s))
              {
                  check = true;
                  break;
              }
          }
          if (!check)
          {
              finalFilteredTable.ImportRow(row);
          }
    }
