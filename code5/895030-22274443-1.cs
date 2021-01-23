    public void Create(Order propertyValues)
    {
        //How to read propertyValues attributes?
        var code = propertyValues.Code;
        var name = propertyValues.ProductName;
    }
    public class Order{
        public int Code {get; set;}
        public string ProductName {get; set;}
    }
    public void CallMethod()
    {
        Create(new Order
        {
            Code = 100,
            ProductName = "P1",
        });
    }
