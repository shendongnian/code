    public class BatchService : IBatchService
    {
        public ICustomerService<Customer> CustService { get; set; }
            
        public void CancelOrders(params int[] orderNos)
        {
            foreach (int orderNo in orderNos)
                CustService.CancelOrder(orderNo);
        }
    }
