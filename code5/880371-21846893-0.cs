    var missionIdList = new List<object>();
    while (sqlreader.Read())
    {
       var obj = new { c1 = Convert.ToInt32(sqlreader[0].ToString()), 
                       c2 = Convert.ToInt32(sqlreader[1].ToString()),
                       c3 = Convert.ToInt32(sqlreader[2].ToString()),
                       uid = uid };
       missionIdList.Add(obj);
    }
