        command = new OleDbCommand(
                "Update Trucks" +
                " SET Trucks.TruckInUse = ? WHERE TFIN = ?", conn);
            command.Parameters.Add(new OleDbParameter("@use", "T"));
            command.Parameters.Add(new OleDbParameter("@tfin", storeTruckSplit));
            command.ExecuteNonQuery();//Commit   
