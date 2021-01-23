    public class DBlogic : DBconnection
    {
         internal void GetUserMessages(String userName)
        {
         var usersId = Db.Usres.Where(a=> a.Username == userName).Select(a => a.Id).FirstOrDefault();
        }
    }
