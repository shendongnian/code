    for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            dgv.Rows.Add(dataset.Tables[0].Rows[i].ItemArray[0].ToString(),
                         dataset.Tables[0].Rows[i].ItemArray[1].ToString(),
                         GetEnumString((int)dataset.Tables[0].Rows[i].ItemArray[2]));
    public enum TableUpdateModeEnum
    {
       INSERT = 0,
       UPDATE_OR_INSERT = 1,
       UPDATE = 2,
       DELETE_OR_INSERT = 3
    };
    private string GetEnumString(int n)
    {
       switch (n)
       {
          case (int)TableUpdateModeEnum.INSERT:
               return "INSERT";
          case (int)TableUpdateModeEnum.UPDATE:
               return "UPDATE";
          case (int)TableUpdateModeEnum.UPDATE_OR_INSERT:
               return "UPDATE/DELETE";
          case (int)TableUpdateModeEnum.DELETE_OR_INSERT:
               return "INSERT/DELETE";
          default: return "";
          }
       }
    }
