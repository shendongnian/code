    public partial class Default : System.Web.UI.Page
    {
      TestClass test = new TestClass();
      DataTable _table = new DataTable();
    
      protected void Button1_Click(object sender, EventArgs e)
        {
    
          FillDataTable ();    // <----------- See this function call
    
         //displaying table
          GridView1.DataSource= _table;
          GridView1.DataBind();
        }
      protected void Button2_Click(object sender, EventArgs e)
        {
    
          FillDataTable ();    // <----------- See this function call
    
          //does not displaying table 
          GridView2.DataSource= _table;
          GridView2.DataBind();
        }
    
        private void FillDataTable()
        {
             if(_table.Rows.Count == 0) 
               _table = test.getTable();
        }
    }
