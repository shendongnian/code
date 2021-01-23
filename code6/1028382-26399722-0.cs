    string query = "select StudentInfoId, Name, Age, State, tbl2.ClassName from tblstudentinfo tbl1 join Class tbl2 on (tbl1.class = tbl2.classid) where 1=1 ";
    
        
        if (name != "")
        {
            query = query + " and name = '" + name + "' " ;
        }
    
        if (age != "")
        {
             query = query + " and age = '" + age + "' ";
        }
    
        if (state != "")
        {
              query = query + " and state = '" + state + "' ";
        }
    
        if (classes != "")
        {
              query = query + " and class = '" + classes + "' ";
        }
