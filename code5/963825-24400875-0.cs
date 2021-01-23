    class DALClass : IDisposable
    {
        private _Connection getConn = new _Connection();
        OleDbConnection _Conn = new OleDbConnection();
        public DataTable getDatatable(string sUserName, string sUserPass)
        {
            //pass on user name and password
            _Conn = getConn.GetConn(sUserName, sUserPass);
            //Do something
            return default(DataTable);  //return datatable 
        }
    }
    public class _Connection
    {
        public OleDbConnection GetConn(string _name, string _pass)
        {
            OleDbConnection _Conn = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User ID={1};Password={2};", @"C:\Test\Test.mdb", _name, _pass));
            return _Conn;
        }
    }
