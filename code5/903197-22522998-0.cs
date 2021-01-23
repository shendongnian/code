    int id = 1;
    string[] employerNos = null;
    
    var query = mydb.MyTable.Where(y => y.ID == id)
    if(employerNos != null)
        query = query.Where(y => employerNos.Contains(y.EmpNo))
    
    var result = query.ToList();
