    try
     {
       if (Latitude != 0 && Longitude != 0)
       {                               
            SqlCommand cmd = new SqlCommand("Insert_Mapapp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Latitude", Latitude));
            cmd.Parameters.Add(new SqlParameter("@Longitude ", Longitude));
            cmd.Parameters.Add(new SqlParameter("@Speed", Speed));
            cmd.Parameters.Add(new SqlParameter("@Battery_ADC ", Battery_ADC));
            cmd.Parameters.Add(new SqlParameter("@sDateTime ", sDateTime));
            cmd.Parameters.Add(new SqlParameter("@Main_Backup_Battery ", Main_Backup_Battery));
            cmd.Parameters.Add(new SqlParameter("@Pulse_Counter ", Pulse_Counter));
            cmd.Parameters.Add(new SqlParameter("@Number_of_Satellites ", Number_of_Satellites));
            cmd.Parameters.Add(new SqlParameter("@IgnitionStatus ", IgnitionStatus));
            cmd.Parameters.Add(new SqlParameter("@Condition_Inputs ", Condition_Inputs));
            cmd.Parameters.Add(new SqlParameter("@FuelADC ", FuelADC));
            cmd.Parameters.Add(new SqlParameter("@UID ", UnitID));
            cmd.Parameters.Add(new SqlParameter("@Device_IP", remoteIP));
            cmd.Parameters.Add(new SqlParameter("@Device_Port", remotePort));
            cmd.Parameters.Add(new SqlParameter("@String_Count", UIDCounter));
            cmd.Parameters.Add(new SqlParameter("@Stored", Stored));
            // cmd.Parameters.Add("@Nofrec", SqlDbType.Int).Direction = ParameterDirection.Output;
            if (cmd.Connection != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
            cmd.ExecuteNonQuery();
      }
     catch (Exception ex)
      {
          throw;
      }
    finally
         {
           if (cmd.Connection.ToString() != String.Empty && cmd.Connection.State != ConnectionState.Closed)
                    CONN.Close();
         }
