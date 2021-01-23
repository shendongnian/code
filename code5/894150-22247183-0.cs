    public partial class MainService : ServiceBase{
        private string SQLConnStr;
    }
    
    class OtherClass{
        private string connstr;
        public OtherClass(string _connstr) { this.connstr = _connstr; }
        public foo() { using(var conn = new SqlConnection(connstr) { ... } }
    }
