       public class shopsAndbikes 
        {
         public List<shop> shops {get;set;}
         public List<bike> bikes {get;set;}
         
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
