    public partial class NorthwindContext 
    {
        public IEnumerable<CustomerOrderHistory> CustomerOrderHistory(string customerID)
        {
            var customerIDParameter = customerID != null ?
                new SqlParameter("@CustomerID", customerID) :
                new SqlParameter("@CustomerID", typeof(string));
            return Database.SqlQuery<CustomerOrderHistory>("CustOrderHist @CustomerID", customerIDParameter);
        }
    }
