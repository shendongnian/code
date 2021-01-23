    try {
       using(var conn = new OleDbConnection(...)) {
          using(var command = new OleDbCommand("SELECT id, password FROM users WHERE username = ...", conn)) {
             conn.Open();
             using(var reader = command.ExecuteReader(...)) {
                if(reader.Read()) {
                   var user = new User {
                      Id = reader.GetInt32(0), PasswordHash = reader.GetString(1)
                   };
                   if(User.SHA2Hash(loginPass) == user.PasswordHash)
                      return user;
                   else
                      return null;  // or throw security exception
                }
             }
          }
       }
    }
    catch(Exception ex) {
       Logger.Error(ex);  // REPORT ERROR! DONT EAT IT
       throw new SecurityException("Login exception", ex);
    }
