    public ActionResult FindOrder(int id)
    {
     
        Order order=DBContext.Orders.FindById(id); // get it from repository
    
        OrderViewModel viewModel=new OrderViewModel();
        viewModel.Id=order.Id; // etc, etc
        //Do this mapping with AutoMapper, recommended
       
        return View(viewModel);
    }
