     public class YourControllerName:apiController
    {
             public IQueryable<AnyNameListDTO> Get()
            {
    
                //Your other Code will go here 
               
                Session["AnyName"] = TheRepository.YourMethodName();
    
    
                
    
            }
     
    }
   
