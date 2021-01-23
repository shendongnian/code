            OleDbConnection cnJetDB = new OleDbConnection(strDB);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "INSERT INTO tableComponents (ComponentDesc) VALUES (?)";
            cmd.Parameters.Add("ComponentDesc", partDesc);
            cnJetDB.Open();
            cmd.Connection = cnJetDB;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT @@IDENTITY";
            int newID = (int)cmd.ExecuteScalar();
            MessageBox.Show(newID.ToString());
            cnJetDB.Close();
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.CommandText = "UPDATE tableComponents SET ComponentCode=@CompCode WHERE ComponentID="+newID;
            cmd2.Parameters.AddWithValue("@CompCode", "PREFIX" + newID.ToString());
            
            cnJetDB.Open();
            cmd2.Connection = cnJetDB;
            cmd2.ExecuteNonQuery();
            cnJetDB.Close();
