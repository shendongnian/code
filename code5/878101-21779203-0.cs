    public bool Validate(string username, string password)
        {
           
            var query = from t in db.Trial_Try
                        join u in db.UserDetails on t.tUID equals u.uID
                        where t.tExpiryDate >= DateTime.Now &&
                        t.tPublication.Value == 163 &&
                        u.uUsername == username &&
                        u.uPassword == password
                        select u; 
            // "execute" the query
            return query.FirstOrDefault() != null; 
        }
