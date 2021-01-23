    public class DBlogic : DBconnection
    {
           internal void WriteToDB(String str){
              //Do something ...
              Db.SaveChanges();
            }
    }
