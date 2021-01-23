      // Since you want to update treeView1 you should 
      // point out on which instance of Form1 the target treeView1 is.
      // That's why LoadTree() can't be static
      public void LoadTree() { // <- Not static!
        // Much better to use a local connection here
        //TODO: provide the right connection string here
        using(OleDbConnection con = new OleDbConnection(connectionString)) {
          con.Open();
          
          // wrap all local IDisposable into using(...) {...}
          using (OleDbCommand populate = new OleDbCommand(con)) {
            // Format out your SQL for it to be readble
            populate.CommandText = 
              "  select Project_Name\n" + 
              "    from Edit_Nodes\n" +
              "order by Location asc";
    
            // wrap all local IDisposable into using(...) {...}
            using (OleDbDataReader reader = populate.ExecuteReader()) {
              // When updating visual controls prevent them from constant re-painting
              // and annoying blinking
              treeView1.BeginUpdate();
    
              try {  
                // What is "j"? No-one knows; "loop" is more readable
                int loop = 1;
 
                while(reader.Read()) {
                  // "var" is unreadable, "nodeText" is clear
                  String nodeText = "H" + loop.ToString() + " - " + reader["Project_Name"];
    
                  // Check ranges: what if SQL returns more recods than treeView1's nodes? 
                  if (loop >= treeView1.Nodes.Count) 
                    break;
    
                  treeView1.Nodes[loop].Text = nodeText;
                
                  loop += 1;
                }
              finally {
                treeView1.EndUpdate();
              }  
            }  
          }
        }
