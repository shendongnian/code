    public class UserService
    {
    
    private DataContext _db;
    //private int _user_id
    
    public UserService(DataContext db)
    {
       _db = db
       //perhaps it would be better to get the user id here
       //rather than pass it in to the methods as a parameter
       //_user_id = GetCurrentUserId();
       //or maybe put HttpContext into DataContext and do this:
       //_user_id = db.GetCurrentUserId();
    }
    
    private List<Message> GetLastTenMessages(int user_id){
            return _db.Messages
                   .Where(x => x.sent == true)
                   .Where(x => x.user_id == user_id)
                   .Where(x => x.date_deleted == null)
                   .OrderBy(x => x.date_sent)
                   .Take(10)
                   .ToList();
    }
    
    private List<Group> GetGroups(int user_id){        
            return _db.Groups
                   .Where(x => x.user_id == user_id)
                   .Where(x => x.date_deleted == null)
                   .OrderBy(x => x.date_created)
                   .ToList();
    }
    
    public MyModel GetSentMessages(int user_id)
    {
            MyModel model = new MyModel();
            model.Messages = GetLastTenMessages(user_id, db);
            model.Groups = GetGroups(user_id, db);
            return model
        }
    }
    }
