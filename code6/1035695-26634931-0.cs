    private void GetCurrencySumByCurrentItemCallBack(IAsyncResult result)
    {
       if(sum != null)
       {
          this.Invoke(new Action(()=>
           {
              //get data grid 
              //set ItemSource
           })
       }
    }
