    public class TContext : ObjectContext
    {
        private IQueryable<User> _allUsers;
       
         public MyContext()
            : base("name=MyEntities", "MyEntities")
        {
            if (this._allUsers == null || _allUsers.Count() == 0)
            {
                LoadAllUsers();
            }
        }
        private void LoadAllUsers()
        {
            ObjectSet<User> userSet = this.CreateObjectSet<User>();
            _allUsers = userSet.Where(x => x.Id > 0);
        }
        private void MyContext_ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            if (_allUsers != null & _allUsers.Count() > 0)
            {
                Type type = e.Entity.GetType();
                // Create user info
                PropertyInfo piBase = type.GetProperty("CreateUser");
                PropertyInfo piObj = type.GetProperty("CreateUserId");
                if (piBase != null && piObj != null)
                {
                    int userId = (int)piObj.GetValue(e.Entity);
                    User createUser = _allUsers.FirstOrDefault(x => x.Id == userId);
                    if (createUser != null)
                    {
                        piBase.SetValue(e.Entity, createUser.Username);
                    }
                }
                piBase = type.GetProperty("CancelUser");
                piObj = type.GetProperty("CancelUserId");
                if (piBase != null && piObj != null)
                {
                    int? userId = (int?)piObj.GetValue(e.Entity);
                    if (userId.HasValue)
                    {
                        User cancelUser = _allUsers.FirstOrDefault(x => x.Id == userId.Value);
                        if (cancelUser != null)
                        {
                            piBase.SetValue(e.Entity, cancelUser.Username);
                        }
                    }
                }
            }
        }
    }
