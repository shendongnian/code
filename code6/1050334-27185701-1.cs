    public void main(string url)
     {
         int var = 0;
         string conn = url;
         OleDbConnection connexion = new OleDbConnection(conn);
         connexion.Open();
         OleDbCommand cmd = new OleDbCommand("SELECT ID, DATA1, DATA2 from Database WHERE ID = ( SELECT MAX (ID) -" + var + " FROM Database);", connexion);
         OleDbDataReader reader = cmd.ExecuteReader();
         reader.Read();
         if (connexion.State == ConnectionState.Open)
         {
             if (!reader.HasRows || (String.IsNullOrEmpty(reader[1].ToString())) && (String.IsNullOrEmpty(reader[2].ToString())))
             {
                 reader.Close();
                 OleDbDataReader reader2 = cmd.ExecuteReader();
                 reader2.Read();
             Found:
                 while (!reader2.HasRows || ((String.IsNullOrEmpty(reader2[1].ToString())) && (String.IsNullOrEmpty(reader2[2].ToString()))))
                 {
                     var++;
                     reader2 = fonction(var, url);
                     reader2.Read();
                     if (!reader2.HasRows)
                     {
                         goto Found;
                     }
                     else if (((!String.IsNullOrEmpty(reader2[1].ToString())) || (!String.IsNullOrEmpty(reader2[2].ToString()))))
                     {
                         data = reader2[1].ToString() + " " + reader2[2].ToString();
                     }
                     else
                     {
                         data = "No Data in Database";
                     }
                 }
                 reader2.Close();
             }
             else
             {
                 data = reader[1].ToString() + " " + reader[2].ToString();
             }
         }
         else
         {
             data = "Connexion KO";
         }
         reader.Close();
         connexion.Close();
     }
