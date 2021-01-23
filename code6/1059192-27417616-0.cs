        public void dropdwnlist(string qry, DropDownList ddl)
        {
           ddl.Items.Clear();
           con.gettable(qry);
           if (con.dt.Rows.Count > 0)
           {
               if (con.dt.Columns.Count == 2)
               {
                   string str1 = con.dt.Columns[0].ColumnName.ToString();
                   string str2 = con.dt.Columns[1].ColumnName.ToString();
                   ddl.DataValueField = str1;
                   ddl.DataTextField = str2;
                   ddl.DataSource = con.dt;
                   ddl.DataBind();
                   con.dt.Columns.Remove(str1);
                   con.dt.Columns.Remove(str2);
               }
               else
               {
                   string str = con.dt.Columns[0].ColumnName.ToString();
                   ddl.DataValueField = str;
                   ddl.DataTextField = str;
                   ddl.DataSource = con.dt;
                   ddl.DataBind();
                   con.dt.Columns.Remove(str);
                   //con.dt.Columns.Remove(str2);
               }    
           }
           ddl.Items.Insert(0, ("--Select--"));
           ddl.SelectedIndex = 0;
        }
