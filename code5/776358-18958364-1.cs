    protected void Button2_Click(object sender, EventArgs e)
                {
            
                  _table = test.getTable();
                 //displaying table
                 GridVieuw2.Datasource = null;
                 GridView2.DataSource= _table;
                 GridView2.DataBind();
               
                }
