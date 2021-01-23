    //I just made up a method but use whatever returns all of them
    var oOrders = _unitOfWork.OrderRepository.GetAll();
    //Create our collection of receipts
    var receipts = new List<string>();
    foreach (var oOrder in oOrders) {
        OrderViewModel vm = new OrderViewModel() { Order = oOrder, Customer = _unitOfWork.CustomerRepository.Find(oOrder.CustomerId) };
        GetEntityViewModelLists(vm);
        receipts.Add(RenderRazorViewToString(ControllerContext, "_Receipt", vm));
    }
    CreatePDF(receipts, filePath);
