    void Update()
    {
      using(SqlConnection c = new SqlConnection(co))
      using(SqlCommand comm = c.CreateCommand())
      {
         string up1 = "Update Scoruri Set Scor=@scor where ID=@id";
         comm.CommandText = up1;
         comm.Parameters.AddWithValue("@scor", Convert.ToInt32(scor1));
         comm.Parameters.AddWithValue("@id", otherForm.id1);
         c.Open();  
         comm.ExecuteNonQuery(); 
         comm.Parameters.Clear();
         comm.Parameters.AddWithValue("@scor", Convert.ToInt32(scor2));
         comm.Parameters.AddWithValue("@id", otherForm.id2);   
         comm.ExecuteNonQuery();       
      }
    }
