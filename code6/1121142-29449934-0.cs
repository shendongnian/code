    namespace IceCreamMaker {
    class Class1
    {
        public struct flavour
        {
            public string flavour_name { get; set; }
            public double Price { get; set; }
            public int Available_quantity { get; set; }
 
            public flavour(string flavour_name, double Price1, int  Available_quantity)
            {
                flavour_name = flavour_name;
                Price = Price1;
                Available_quantity = Available_quantity;
            }
        }
        public struct topping
        {
            public string Topping_type { get; set; }
            public double Price { get; set; }
            public topping(string Topping_type, double Price2)
            {
                Topping_type = Topping_type;
                Price = Price2;
            }
        }
        public flavour flavours[];
        public topping toppings[];
        public Class1()
        {
            flavours = new flavour[50];
            toppings = new topping[50];
        }
    }
