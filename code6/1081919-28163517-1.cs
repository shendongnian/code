    public class CompoundModel
    {
        public Entities.Order { get; set; }
        public Entities.Item { get; set; }
    } 
    public List<CompoundModel> getTransdataByStatus(string status)
    {
        contenxt = new Finance_ManagementEntity();
        var  _result = (from a in contenxt.Orders
                        join b in contenxt.Items on a.item_id equals b.item_id
                        select new CompoundModel
                        {
                            Order = a
                            Item = b
                        });
       return _result;
    }
