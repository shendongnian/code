            var klasList = new List<KlasStruct>();
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
                          klasList2.Add(new KlasStruct() { Naam = KlasReader["Naam"].ToString());
                       }
                       connect.Close();
                       
                       Klas =  klasList.ToArray();
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
