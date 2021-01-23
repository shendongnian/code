    class PriceCondition {
      public Product SalesCode { get; private set; }
      public ControlDate Condition { get; private set; }
      public PriceDetail Pricing { get; private set; }
      public PriceCondition(Product salesCode) {
        SalesCode = salesCode;
        Condition = null;
        Pricing = null;
      }
      public PriceCondition(ControlDate condition, PriceDetail pricing) {
        SalesCode = null;
        Condition = condition;
        Pricing = pricing;
      }
    }
