    public void GetAllDistricts() {
    
            DBHelper.Instance.onQueryResult += 
                      new QueryResultEventHandler(GetAllDistricsResultHandler);
    
           new Thread(
               new ThreadStart(DBHelper.Instance.GetAllDistricts)
                ).Start();
      
        }
