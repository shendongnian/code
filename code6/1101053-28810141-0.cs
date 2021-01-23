    1. Move all the code in Page_Load event as follows.
         
    protected void Page_Load(object sender, Event args)
        {
           if(!IsPostBack)
           {
              // all your code here which should be executed only once
           }
        }
    
         2. Make the following change here.
        
             <%@ Page EnableEventValidation="false" %>
