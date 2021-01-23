    // interfaces must be public - this is the "contract" with the outside world / assemblies
    public interface IDatabase
    {
        void Create(DataObject obj);
    }
    
    // classes that implement interfaces should be internal - outside world don't know about them
    internal class SQLDatabase : IDatabase
    {
        // internal on constructor helps you to make sure you are the only one 
        // that can create such an instance
        internal SQLDatabase()
        {
        }
        void Create(DataObject obj)
        {
            Entity dbContext = new Entity();
            dbContext.Data.Add(obj);
            dbContext.SaveChanged();
        }
    }
    internal class OracleDatabase : IDatabase
    {
        internal OracleDatabase()
        {
        }
        void Create(DataObject obj)
        {
            //oracle creation method
        }
    }
    public class DataObject
    {
        int Data1;
        string Data2;
    }
    // this is the factory class that creates the instances for you (ourside world)
    public class DatabaseFactory
    {
        // you can use either params or ideally app.config keys
        public IDatabase CreateInstace()
        {
            if (ConfigSetting == "SQL")
            {
                return new SQLDatabase();
            }
            else if (ConfigSetting == "Oracle")
            {
                return new OracleDatabase();
            }
            else throw new System.Exception ("invalid configuration setting key");
        }
    }
    
    // this is in external assembly:
    public class CreateElementOnDatabase
    {
         DataObject myObj = new DataObject();
         myObj.Data1 = 10;
         myObj.Data2 = "Test String";
        // you only work with public interfaces
        // and the factory creates the instances for you ...
         IDatabase db = DatabaseFactory.CreateInstace();
         db.Create(myObj);
    }
