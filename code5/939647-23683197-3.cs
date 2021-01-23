    public class ProductsDAO : CassandraDAO
    {
        public List<Product> getProducts(string _itemID)
        {
            string strCQL = "SELECT priceAvail, productGroup, productSpec, sizeProfile "
                + "FROM products.itemsmaster "
                + "WHERE itemID=?";
            Session localSession = getSession();
            PreparedStatement statement = localSession.Prepare(strCQL);
            BoundStatement boundStatement = new BoundStatement(statement);
            boundStatement.Bind(_itemID);
            //get result set from Cassandra
            RowSet results = localSession.Execute(boundStatement);
            List<Product> returnVal = new List<Product>();
            foreach (Row row in results.GetRows())
            {
                Product tempProd = new Product();
                tempProd.itemID= _itemID;
                tempProd.priceAvail = row.GetValue<int>("priceavail");
                tempProd.productGroup = row.GetValue<string>("productgroup");
                tempProd.productSpec = row.GetValue<string>("productspec");
                tempProd.sizeProfile = row.GetValue<string>("sizeprofile");
                returnVal.Add(tempProd);
            }
            return returnVal;
        }
