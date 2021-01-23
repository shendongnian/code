    private int _theDay = DateTime.Now.Day;
    public int TheDay
    {
         get 
         {
             if(Request.QueryString["d"] != null) 
                  _theDay =  Convert.ToInt16(Request.QueryString["d"]);             
             return _theDay; 
         }
         set 
         {
            if ( value <= 31 && value > 0 )
            {
                _theDay= value;
            }
            else 
            {
                _theDay= DateTime.Now.Day;
            }
        }
    }
