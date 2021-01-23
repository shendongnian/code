    public class UserService
    {
        public UserService(DataContext db)
        {
           _db = db;
           _msgRepo = new MessageRepository(_db.Messages);
           _groupsRepo = new GroupsRepository(_db.Groups);
        }
    
        public MyModel GetSentMessages()
        {
                MyModel model = new MyModel();
                model.Messages = _msgRepo.GetLastTenMessages(db.user_id);
                model.Groups = _groupsRepo.GetGroups(db.user_id);
                return model
            }
        }
    }
