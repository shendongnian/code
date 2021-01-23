    // code change starts
    private bool _isGridRefreshing
    {
       get
       {
          var flag = HttpContext.Current.Session["IsGridSession"];
          if(flag != null)
          {
             return (bool)flag;
          }
          
          return false;
       }
       set
       {
          HttpContext.Current.Session["IsGridSession"] = value;
       }
    }
    // code change ends
    
    protected void Timer1_Tick(object sender, EventArgs e)
    {
       if(_isGridRefreshing == false)
       {
           RefreshGrid();
       }
    }
    
    private void RefreshGrid()
    {
       _isGridRefreshing = true;
    
       //code to refresh the grid.
    }
