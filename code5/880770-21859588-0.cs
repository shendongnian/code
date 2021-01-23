    string sqlCommand = @"UPDATE Registration SET [Year]=?, No_of_Candidates=?, Event=?
                         WHERE  contact=?";
    command = new OleDbCommand(sqlCommand, conn);
    command.Parameters.Add("@year", OleDbType.VarChar).Value = GetYearValue();  //integer??
    command.Parameters.Add("@noc", OleDbType.VarChar).Value = GetNumberCanditatesValue();  //integer?
    command.Parameters.Add("@evt", OleDbType.VarChar).Value = GetEventValue();  
    command.Parameters.Add("@cont", OleDbType.VarChar).Value = TextBox4.Text;
      
