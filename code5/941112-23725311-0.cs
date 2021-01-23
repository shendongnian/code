        public user GetUser(int userId)
        {
            using (var db = new Database("LocalMySqlServer"))
            {
                var sql = NPoco.Sql.Builder.Append("SELECT * FROM users where ID=@0", userId);
                var myList = db.FirstOrDefault<user>(sql);
                return myList;
            }
        }        
        public List<user> GetUsers()
        {
            using (var db = new Database("LocalMySqlServer"))
            {
                return db.Fetch<user>("SELECT * FROM users");
            }
        }
