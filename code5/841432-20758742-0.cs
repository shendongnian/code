    using (var item = pr.sqlDataReader(sql))
    { 
        // call .Read() on the SqlDataReader - and this *COULD* return multiple rows! 
        // Not just one - it could return many - so you'll need to handle that somehow.....
        while (item.Read()) 
        {
           Commands cmd = new Commands
                             {
                               cID = item.GetInt32(0),
                               cName = item.GetString(1),
                               cType = item.GetInt32(2),
                               msgID = item.GetInt32(3)
                           };
           // store all those "Commands" retrieved into a list or something and return them
        }
    }
