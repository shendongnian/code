    void Dataadd() { // <- Probably DataAdd will be better name
      string connection = "Data Source=CD_PC\MSSQL;Initial Catalog=example;Integrated Security=True"; 
    
      // Format your code; let SQL be read as formatted SQL, not long, long line...
      string query = 
        "select *\n" +
        "  from student;"; 
    
      try {
        // Use "using" on IDisposable insatnces
        using (SqlConnection conn = new SqlConnection(connection)) {
          conn.Open();
    
          using(SqlCommand cmd = new SqlCommand(query, conn)) {
            using(SqlDataReader rdr = cmd.ExecuteReader()) {
              while (rdr.Read()) { 
                string sName = rdr.GetString(0); // <- 0 stands for the 1st field; 
    
                comboBox1.Items.Add(sName);  
              }  
            }
          }
        }
      }
      catch (DataException ex) { // <- Never ignore ALL the exceptions: catch(Exception e) 
        MessageBox.Show(ex.Message);
      } 
    }
