    NpgsqlCommand command = new NpgsqlCommand("UPDATE sessions SET \"Visit Number:\" = @visitnum,\"ENTERED BY:\" = @enteredby  WHERE \"Visit Number:\" = @visitnum", this.connection);
    command.Parameters.Add("@visitnum", NpgsqlTypes.NpgsqlDbType.Integer, 12, "Visit Number:");
    command.Parameters.Add("@enteredby", NpgsqlTypes.NpgsqlDbType.Varchar, 50, "ENTERED BY:");
    NpgsqlParameter parameter = command.Parameters.Add("@oldvisitnum", NpgsqlTypes.NpgsqlDbType.Integer, 12, "Visit Number:");
    parameter.SourceVersion = DataRowVersion.Original;
    NpAdapter.UpdateCommand = command;
    NpAdapter.Update(dset,"sessions");
    MessageBox.Show("Data Updated!!!");
