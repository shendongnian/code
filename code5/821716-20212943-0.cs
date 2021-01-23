       public class shopsAndbikes 
        {
         publick List<shops> shops {get;set;}
         publick List<bikes > bikes {get;set;}
         
        }
        
        public ActionResult Index()
        {             
           shopsAndbikes vm = new shopsAndbikes ()
           {
            var shops = this.context.shops.Select(q => new { q.id, q.name }).ToList();
            var bikes = this.context.bikes.Select(q => new { q.id, q.name }).ToList();
           }
          return View(vm);    
        }
