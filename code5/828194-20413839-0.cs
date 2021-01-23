       public static int findNullRow(DataTable dt)
       {
           int row = 0;
           for (int a = 0; a < dt.Rows.Count; a++)
           {
               if (dt.Rows[a][0] == null)
               {
                   row = a;
                   break;
               }
           }
           return row;
       }
       public static int findNullColumn(DataTable dt)
       {
           int col = 0;
           for (int i = 0; i < dt.Columns.Count; i++)
           {
               if (dt.Rows[0][i] == null)
               {
                   col = i;
                   break;
               }
           }
           return col;
       }
