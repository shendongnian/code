    // CREATE TABLE DateStorage
    // (
    //     Dates date
    // )
    DateTime now = DateTime.Now;
    // now.ToString() ->  2013-05-24 09:39:00.0000000+00:00
    
    // ---- INSERT ------
    Db.Insert("DateStorage", now);
    
    // Dates
    // --------------
    // 2013-05-24
    
    // ----- READ ----- 
    DateTime date = Db.Read("DateStorage").Rows[0]["Dates"] as DateTime;
    // date.ToString() => 2013-05-24 00:00:00.00000 +00:00
