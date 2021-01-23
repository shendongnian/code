    //Controller
    public ActionResult Index()
    {
      List<OrderViewModel>() model = new List<OrderViewModel>();  
      model = new ServiceClass().GetOrders();
    
      return View(model);
    }
    //here is your Service Class, this layer transfers the Domain Model into your ViewModel
    public List<OrderViewModel> GetOrders()
    {
       List<OrderDomain> model = new List<OrderDomain>();
       
       model = new DataAccess().GetOrders();
    
       List<OrderViewModel> viewModel = new List<OrderViewModel>();
       
       foreach (var order in model)
       {
            OrderViewModel vm = new OrderViewModel();
            vm.OrderId = order.OrderId;
            vm.OrderName = order.OrderName;
        
            viewModel.Add(vm);
       }      
    
        return viewModel;        
    }
    //some DataAccess class, this class is used for database access
    
    Public List<OrderDomain> GetOrders()
    {
         List<OrderDomain> model = new List<OrderDomain>();
          using (var context = new MyEntities())
          {
              model = (from x in context.Order
                       select new OrderDomain
                       {
                         OrderId = x.OrderId,
                         OrderName = x.OrderName
                       }).ToList();                     
          }
       return model;
    }
   
