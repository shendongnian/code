    public class CompoundModel
    {
        public string OrderNumber { get; set; }
        public int Total { get; set; }
        public string ItemCode { get; set; }
        public int ItemQuantity { get; set }
    }
    public List<CompoundModel> getTransdataByStatus(string status)
    {
        contenxt = new Finance_ManagementEntity();
        var  _result = (from a in contenxt.Orders
                        join b in contenxt.Items on a.item_id equals b.item_id
                        select new CompoundModel
                        {
                            OrderNumber = a.order_number,
                            Total = a.total,
                            ItemCode = b.item_code,
                            ItemQuantity = b.item_qty
                        });
       return _result;
    }
