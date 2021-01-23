            OdbcConnection DbConnection = new OdbcConnection("DSN=SAMPLE_ISAM");
            DbConnection.Open();
            OdbcCommand DbCommand = DbConnection.CreateCommand();
            DbCommand.CommandText = "SELECT Attachments.FileData, ID, Attachments.FileName FROM Complaints WHERE ID IN(29,30)";
            OdbcDataReader DbReader = DbCommand.ExecuteReader();
            int fCount = DbReader.FieldCount;
            while (DbReader.Read())
            {
                byte[] bytes = (byte[])DbReader[0];
                Int32 ID = (Int32)DbReader[1];
                string name = (string)DbReader[2];
                File.WriteAllBytes(@"D:\files\" + name, bytes.Skip((int)bytes[0]).ToArray());
            }
            DbReader.Close();
            DbCommand.Dispose();
            DbConnection.Close();
