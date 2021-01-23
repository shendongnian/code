    public InfoContract  GetOrderDetails(string OrderID){ 
         
         ...
         var infoContract = new InfoContract();
         infoContract.Add(order );
         return infoContract;
    }
