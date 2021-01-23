    @using Composite.Data
    @inherits RazorFunction
     
    @functions {
        public override string FunctionDescription
        {
            get  { return "..."; }
        }   
    }
    
    <html xmlns="http://www.w3.org/1999/xhtml" xmlns:f="http://www.composite.net/ns/function/1.0">
        <head>
        </head>
        <body>
    
            @using (DataConnection dataConnection = new DataConnection())
            {
                // (1) get the current page ID
                
                SitemapNavigator sitemapNavigator = new SitemapNavigator(dataConnection);
    
                Guid PageId = sitemapNavigator.CurrentPageNode.Id;
    
                if (PageId != null)
                {
                    
                // (2) Get the meta field from the current page
                          
                    var myTag = Data.Get<My.Meta.Type>().Where(t => t.PageId == PageId).FirstOrDefault();
                
                // (3) Process the tag the way you like
                    
                    if(myTag != null)
                    { 
                        <p>@myTag.Tag</p>
                    }
                }
            }
    
        </body>
    </html>
