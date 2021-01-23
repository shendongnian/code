    using (var command = new SqlCommand("sp_AddNewEquipment", dbconn) { 
                               CommandType = CommandType.StoredProcedure }) {
       dbconn.Open();
       command.Parameters.Add(new SqlParameter("@EquipmentNo", eq.SerialNo));
       //add other parameters here
       command.ExecuteNonQuery();
       dbconn.Close();
    }
