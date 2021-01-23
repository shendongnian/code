    IQueriable result = 
        from p in personnelList
        join g in GenderLIst on p.GenderId=g.GenderId
        select new 
        {
            PersonId = p.PersonId,
            FullName = p.FirstName + " " + p.LastName,
            GenderId = p.GenderId,
            GenderName = g.GenderName
        };
     }
