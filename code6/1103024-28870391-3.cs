    public class Dropdown
    {
    Connection con = new Connection();
    public void dropdwnlist(string qry, DropDownList ddl)
    {
	DataTable dt =con.gettable(qry);
       if (dt.Rows.Count > 0)
       {
           if (dt.Columns.Count == 2)
           {
               string str1 = dt.Columns[0].ColumnName.ToString();
               string str2 = dt.Columns[1].ColumnName.ToString();
               ddl.DataValueField = str1;
               ddl.DataTextField = str2;
               ddl.DataSource = dt;
               ddl.DataBind();
               dt.Columns.Remove(str1);
               dt.Columns.Remove(str2);
           }
           else
           {  
               string str = dt.Columns[0].ColumnName.ToString();
               ddl.DataValueField = str;
               ddl.DataTextField = str;
               ddl.DataSource = dt;
               ddl.DataBind();
               dt.Columns.Remove(str);
           }
       } 
           ddl.Items.Insert(0, ("--Select--"));
        }
     }  
