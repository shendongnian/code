    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
     public abstract class EnforceMyBusinessRulesController : ApiController
    {
    
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
    
            /*
    
                Use any of these to enforce your rules;
    	
                http://msdn.microsoft.com/en-us/library/system.web.http.apicontroller%28v=vs.108%29.aspx
    	
                Public property	Configuration	Gets or sets the HttpConfiguration of the current ApiController.
                Public property	ControllerContext	Gets the HttpControllerContext of the current ApiController.
                Public property	ModelState	Gets the model state after the model binding process.
                Public property	Request	Gets or sets the HttpRequestMessage of the current ApiController.
                Public property	Url	Returns an instance of a UrlHelper, which is used to generate URLs to other APIs.
                Public property	User	Returns the current principal associated with this request. 
            */        
        
    		  base.Initialize();
    		  
    		  bool iDontLikeYou = true; /* Your rules here */
    			if (iDontLikeYou)
    			{
    				throw new HttpResponseException(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.NotFound));
    			}
    		  
    	
        }
    
    }
    }
    
    
    
    
    public class ProductsController : EnforceMyBusinessRulesController
    {
    
        protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
        {
    	  base.Initialize();
        }
    
    }
