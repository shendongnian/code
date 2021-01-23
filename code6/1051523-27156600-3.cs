    public class Purchase
        {
            public Decimal Discount { get; set; }
            public Boolean Discounted { get; set; }
            public String Name { get; set; }
            public Decimal Price { get; set; }
            public Int32 Count { get; set; }
    
            public Decimal FinalPrice
            {
                get
                {
                    if (!Discounted)
                        return Price;
                    else
                        return Price - Discount;
                }
            }
    
            public Purchase (String csvString){
                string[] parameters = csvString.Split(';');
    
                Name = parameters[0];
                Price = decimal.Parse(parameters[1]);
                Count = int.Parse(parameters[2]);
    
                if (parameters.Length == 4)
                {
                    Discount = decimal.Parse(parameters[3]);
                    Discounted = true;
                }
            }
        }
