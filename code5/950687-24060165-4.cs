         if (dataReader.Read())
            {
             for (int i = 0; i < dataReader.FieldCount;i++ )
               {
                dataReader.GetName(i);
                dataReader.GetValue(i);
                this.Add(TreeItemInfo.GetItem(Convert.ToString(dataReader.GetName(i)),
    Convert.ToString(dataReader.GetValue(i))));
                }
          }
