            var klasList = new List<String>();
            // Or any other type
            var klasList2 = new List<Klas>();
            connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\Project Officieel\Project_MagnusCurriculum\Project_MagnusCurriculum\Project.accdb";
               connect.Open();
               OleDbCommand cmdKlassen = new OleDbCommand("SELECT Naam FROM RichtingEnJaar WHERE ID = 1", connect);
               if (connect.State == ConnectionState.Open)
               {    
                   try
                   {
                       OleDbDataReader KlasReader = null;
                       KlasReader = cmdKlassen.ExecuteReader();
                       while (KlasReader.Read())
                       {
                          klasList.Add(KlasReader["Naam"].ToString());
                          klasList2.Add(new Klas() { Naam = KlasReader["Naam"].ToString());
                       }
                       connect.Close();
                       // returns array of klas naam
                       // return KlasList.ToArray();
                       // returns array of klas
                       return klasList2.ToArray();
                   }
                   catch (Exception expe)
                   {
                       MessageBox.Show(expe.Source);
                       connect.Close();
                   }
              }
              else
              {
                  MessageBox.Show("Connection failed");
              }
