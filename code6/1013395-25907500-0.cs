    public TextValuePair[] FindAllUserByNotThisId(int id)
            {
                TextValuePair[] users=null;
                var userids = _uow.UserInGroups.GetAll().Where(x => x.GroupId ==  id).ToList().Select(s=>s.UserId);
    
                   users=  _uow.Users.GetAll().Where(x => !userids.Contains(x.UserId)).ToList()
                           .Select(
                               s =>
                               new TextValuePair
                               {
                                   Text = s.UserName,
                                   Value = s.UserId.ToString()
                               })
                           .ToArray();
                return users;
            }
