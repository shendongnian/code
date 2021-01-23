    SQLiteConnection con = new SQLiteConnection(/*Your Connection String*/);
    string AddFormationTop = "INSERT INTO Formation (WellID, Param1, Param2, Param3) 
    VALUES ((SELECT WellID FROM Wells WHERE WellName = @WellName), @Param1, @Param2, @Param3)";
    SQLiteCommand cmd = new SQLiteCommand(AddFormationTop, con);
    string pParam1;
    double pParam2;
    double pParam3;
    con.Open();
    // of course, your "for" case might be different.  
    for (int i = 1; i < GlobalVar.Formation.Length - 1; i++)
        {
         pParam1 = GlobalVar.Param1[i];
         pParam2 = Convert.ToDouble(GlobalVar.Param2[i]);
         pParam3 = Convert.ToDouble(GlobalVar.Param3[i]);
         cmd.Parameters.AddWithValue("@WellName", Properties.Settings.Default.ActiveWell);
         cmd.Parameters.AddWithValue("@Param1", pParam1);
         cmd.Parameters.AddWithValue("@Param2", pParam2);
         cmd.Parameters.AddWithValue("@Param3", pParam3);
         cmd.ExecuteNonQuery();
         }
    con.Close();
