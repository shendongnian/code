    private libDBDataContext _DB = null;
    public libDBDataContext DBContext 
    { 
        get 
        {
            if (_DB == null)
            {
                _DB = new libDBDataContext();
            }
            return _DB; 
         }
 
         set { _DB = value; }
    }
