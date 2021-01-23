    List<Test> test = new List<Test> 
    {
        new Test(
            name: "ABC",
            firstAmount: 10,
            secondAmount: 20                                                                                            
        )
    };    
    public class Test
    {
        public Test(string name, decimal firstAmount, decimal secondAmount)
        {
            Name = name;
            FirstAmount = firstAmount;
            SecondAmount = secondAmount;
            TotalAmount = firstAmount + secondAmount;
        }
        public String Name { get; set; }
        public decimal FirstAmount { get; set; }
        public decimal SecondAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }   
