    public InfoContract  GetOrderDetails(string OrderID){ 
         
         ...
         var infoContract = new InfoContract();
         infoContract.Info.Add(order );
         return infoContract;
    }
