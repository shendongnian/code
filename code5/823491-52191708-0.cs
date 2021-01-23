    public partial class YourEntitities
    {
        public void SetDatabase(string dataBase)
        {
            string connString = Database.Connection.ConnectionString;
            Regex rgx = new Regex(@"(?<=initial catalog=)\w+");
            string newconnString = rgx.Replace(connString, dataBase);
            //string  = connString.Replace("{database}", dataBase);
            Database.Connection.ConnectionString = newconnString;
        }
    }
