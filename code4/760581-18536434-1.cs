    using (var command = new SqlCommand("sp_AddNewEquipment", dbconn) { 
                               CommandType = CommandType.StoredProcedure }) {
       dbconn.Open();
       command.Parameters.Add(new SqlParameter("@EquipmentNo", eq.SerialNo));       
       command.Parameters.Add(new SqlParameter("@EquipmentDescription", eq.EquipmentDescription));
       command.Parameters.Add(new SqlParameter("@SerialNo",eq.SerialNo));
       command.Parameters.Add(new SqlParameter("@Barcode",eq.Barcode));
       command.Parameters.Add(new SqlParameter("@CategoryID",eq.CategoryID));
       command.Parameters.Add(new SqlParameter("@VenueID",eq.VenueID));
       command.ExecuteNonQuery();
       dbconn.Close();
    }
