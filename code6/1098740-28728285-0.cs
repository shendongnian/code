    public class TestOrderBuilder
    {
        private order = new Order();
        //  These methods represent sentances / grammar that describe the sort   
        //  of test data you are building
        public AnObjectBuilder AddHighQuantityOrderLine()
        {
             //... code to add a high quantity order line
             return this; // for method chaining
        }
        //  These methods represent sentances / grammar that describe the sort   
        //  of test data you are building
        public AnObjectBuilder MakeDescriptionInvalid()
        {
             //... code to set descriptions etc...
             return this; // for method chaining
        }
        public Order Order
        {
             get { return this.order; }
        }
    }
 
    // then using it:
    var order = new TestOrderBuilder()
                     .AddHighQuantityOrderLine()
                     .MakeDescriptionInvalid()
                     .Order
