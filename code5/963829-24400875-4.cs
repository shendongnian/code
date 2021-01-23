    class BLClass
    {
        DALClass _dal;
        public string sUserName;
        public string sUserPass;
        public BLClass()
        {
            _dal = new DALClass();            
        }
        public DataTable GetDataTable()
        {
            return _dal.getDatatable(sUserName, sUserPass);
        }
    }
