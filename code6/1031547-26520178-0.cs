    myCommand.Parameters.Add("empID", SqlDbType.BigInt).Direction =ParameterDirection.Output;
    myCommand.Parameters.Add("empMonitorID ", SqlDbType.BigInt).Direction = ParameterDirection.Output;
    myCommand.ExecuteScalar();
    MessageBox.Show(myCommand.Parameters["empID"].Value.ToString());
    MessageBox.Show(myCommand.Parameters["empMonitorID "].Value.ToString());
