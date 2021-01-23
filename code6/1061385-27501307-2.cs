    List<OrderProduct> orderProducts = new List<OrderProduct>();
    var elements = (Driver.FindElements(By.XPath("//*[@id=\"productorderelement\"]")))
    foreach (element in elements)
    {
        orderProducts.Add(CreateOrderProduct(element));
    }
    public class OrderProduct
    {
        public string BrandName{get;set;}
        public int Quantity{get;set;}
        public double Price{get;set;}    
    }
    public OrderProduct CreateOrderProduct(IWebElement element)
    {
         return new OrderProduct()
         {
              BrandName= element.Something, //you need to extract the appropriate bit of the webelement that holds the brandname, quantity and price, but you don't show us the structure so I can't help there
              Quantity= element.FindElement(By.Class("quantity")).Text, //for example
              Price= element.GetAttribute("Price") //again another example
         }
    }
