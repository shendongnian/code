    //This Works for me in WPF C#: 
    
    int MaxNum=0;
    sqliteCon.Open();
    string Query = "SELECT MAX(Promo_No)FROM Promo_File";
    SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
    SQLiteDataReader DR = createCommand.ExecuteReader();
    while (DR.Read())
    {
       MaxNum = DR.GetInt16(0);
    }
    sqliteCon.Close();
