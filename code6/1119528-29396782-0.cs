    public class Order
    {
        //consider renaming as appropriate
        public static Expression<Func<Order, bool>> Finishable
        {
            get
            {
                //TODO change logic in lambda as needed
                return order => order.Status == "Finished";
            }
        }
    }
