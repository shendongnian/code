    public class OrderController : BaseController
    {
        private IOrderProcessor ordeProcessor;
    
        public OrderController (IOrderProcessor processor)
        {
           this.ordeProcessor= processor;
        }
    
        public ActionResult Create (OrderOL obj)
        {
           var result = processor.Process(obj)
           return view();
        }
    }
