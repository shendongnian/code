        public class userGroup
        {
            class user
            {
                private int id { get; set; }
                private string name { get; set; }
                private Guid grpId { get; set; }
                
                public int userId { get { return id; } set { id = value; } }
                public string userName { get { return name; } set { name = value; } }
                public Guid groupId { get { return grpId; } set { grpId = value; } }
                public user() { }
            }
            class group
            {
                private Guid id { get; set; }
                private string name { get; set; }
                
                public List<user> usersInGroup = new List<user>();
                public Guid groupId { get { return id; } set { id = value; } }
                public string groupName { get { return name; } set { name = value; } }
                public group() { }
            }
            
            public userGroup() { }
            public group getUserGroup() 
            {
                group x = new group();
                Guid newGroupId = Guid.NewGuid();
                x.groupId = newGroupId;
                var userQuery = myDB.Where(n => n.myField == myConditon).Select(n => new
                {
                    n.userId,//I'm assuming that the database query returns a field userId
                    n.userName//I'm assuming that the database query returns a field userName
                });
                
                foreach(var user in userQuery)
                {
                    userGroup.user y = new userGroup.user();
                    
                    y.groupId = newGroupId;
                    
                    y.userId = user.userId;
                    y.userName = user.userName;
                    x.usersInGroup.Add(user);    
                }
                 
                return x;
            }
        }
