    class BLClass
    {
        DALClass _dal;       
        public BLClass()
        {
            _dal = new DALClass();            
        }
        public DataTable GetDataTable(string sUserName, string sUserPass)
        {
            return _dal.getDatatable(sUserName, sUserPass);
        }
    }
