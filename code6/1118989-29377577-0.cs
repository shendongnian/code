        public class PriceCondition
    {
        private Product m_Product;
        private ControlDate m_ControlDate;
        public PriceCondition(Product product)
        {
            m_Product = product;
        }
        public PriceCondition(ControlDate controlDate)
        {
            m_ControlDate = controlDate;
        }
        public Product SalesCode
        {
            get { return m_product; }
        }
        public ControlDate Condition
        {
            get { return m_ControlDate; }
        }
    }
