    public void GenerateColumns()
      {
       dtblDummy = new DataTable("dtblDummy");
    
       dtDummyColumn = new DataColumn("FirstName");
       dtblDummy.Columns.Add(dtDummyColumn);
    
       dtDummyColumn = new DataColumn("LastName");
       dtblDummy.Columns.Add(dtDummyColumn);
    
       dtDummyColumn = new DataColumn("Email");
       dtblDummy.Columns.Add(dtDummyColumn);
    
       dtDummyColumn = new DataColumn("Login");
       dtblDummy.Columns.Add(dtDummyColumn);
       
       dtDummyColumn = new DataColumn("Password");
       dtblDummy.Columns.Add(dtDummyColumn);
    
       dtDummyColumn = new DataColumn("Role");
       dtblDummy.Columns.Add(dtDummyColumn);
    
       dtDummyColumn = new DataColumn("RoleId");
       dtblDummy.Columns.Add(dtDummyColumn);   
      }
     
      public void GenerateRows(int intRow)
      {
       for(int intCounter = intRow; intCounter < intRow; intCounter++)
       {
        dtDummyRow = dtblDummy.NewRow();
    
        dtDummyRow["FirstName"] = "";
        dtDummyRow["LastName"] = "";
        dtDummyRow["Email"] = "";
        dtDummyRow["Login"] = "";
        dtblDummy.Rows.Add(dtDummyRow);
       }
        
       dgrdUsers.DataSource = dtblDummy;
       dgrdUsers.DataBind();
    
       dtblDummy = null;
       dtDummyRow = null;
       dtDummyColumn = null;
      }
 
