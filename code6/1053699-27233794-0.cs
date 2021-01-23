    public static void ActualizarPacienteNn(Int64 idPacienteNN, Int64 idPaciente, string nombreUsuario, string contrasena)
    {
      //Establish connection
      OracleConnection conexion = new OracleConnection();
      conexion = GenerarConexionOracle(nombreUsuario, contrasena);
      
      conexion.Open();
      //Set up comando to reference stored procedure 'usp_ActualizaPaciente'
      OracleCommand comando = new OracleCommand("usp_ActualizaPaciente", myConn);
      comando.CommandType = System.Data.CommandType.StoredProcedure;
      comando.ParameterCheck = true;
     
      //Sample of how to bind parameters to the Stored Procedure
      OracleParameter myInParam1 = new OracleParameter();
      myInParam1.Value = idPaciente;
      myInParam1.ParameterName = "idPaciente";
      comando.Parameters.Add(myInParam1);
      myInParam1.Direction = System.Data.ParameterDirection.Input;
     
      //Execute the procedure.
      comando.ExecuteNonQuery();
      Console.WriteLine("Done");
      conexion.Close();
    }
