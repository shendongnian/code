    private void btnSavePoints_Click(object sender, EventArgs e)
    {
        con = new SqlConnection(CONNSTRING);
        cmd4 = new SqlCommand("UPDATE SadaTestTable SET Points = @pts WHERE id = @id",con);
        cmd4.Parameters.AddWithValue("@id", Datatype.Char);//if the datatype in the database is char but if the data type in the database is int then is datatype.int
        PointsGiven = Convert.ToInt32(tbPointsGiven.Text);
        cmd4.Parameters.AddWithValue("@pts", PointsGiven);
         try
       {
             con.open();//here open my connection 
             cmd4.connection = con;  
            Afrows = cmd4.ExecutenonQuery();//Execute my query
       }
      catch
       {
          throw;//possible exceptions in the system
       }
      finally
       {
           con.Close();//closing connections
       }
        
  
    }
