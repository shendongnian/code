    public Array Get(string id)
            {
                //return "value";
                string userName = id.ToString();
    
                using (var db = new SDCLogins())
                {
                    var query = from logins in db.logins.AsEnumerable()
                                join loginTypes in db.loginTypes on new { loginType = logins.loginType } equals new { loginType = loginTypes.loginTypeID }
                                where
                                  logins.uname == userName
                                select new
                                {
                                    logins.login1,
                                    startDate = logins.startDate.HasValue ? (object) logins.startDate.Value.ToShortDateString() : DBNull.Value,
                                    stopDate = logins.stopDate.HasValue ? (object) logins.stopDate.Value.ToShortDateString() : DBNull.Value,
                                    createdDate = logins.createdDate.HasValue ? (object) logins.createdDate.Value.ToShortDateString() : DBNull.Value,
                                    logins.createdBy,
                                    loginTypes.loginDescription
                                };
    
                    return query.ToArray();
                }
    
            }
    
