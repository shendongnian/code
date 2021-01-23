    string strDate = "2015-03-23 11:22:33.123";
    DateTime datDate = DateTime.Parse(strDate);
    // ...
    //    command.Parameters.AddWithValue("@Date", datDate ); // <-- error here 
    command.Parameters.Add("@Date",OleDbType.Date);
    command.Parameters[0].Value = datDate;                    // <-- no error
