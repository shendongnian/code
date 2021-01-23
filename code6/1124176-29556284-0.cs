     void Default_Method(Action additionalMethod = null)
     {
         //default logic
         //after default logic, call additional method if its name was specified
         
         //This if is needed to avoid NullReferenceException
         if (additionalMethod != null)
             additionalMethod();
     }
    
     void Additional_Method()
     {
         //additional logic
     }
    protected void Page_Load(object sender, EventArgs e)
    {
         Default_Method(Additional_Method);
         //OR
         Default_Method();
         //OR
         Default_Method(null);
         //OR
         Default_Method(() => { /*Do something*/}); 
    }
