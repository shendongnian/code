    public Page1: BaseClass
    {
         public void Method1()
         {
             base.BaseMethod();
         }
    }
    
    public BaseClass: System.Web.UI.Page
    {
        //.. specify your method here
        protected BaseMethod()
        {
             
        }
    }
