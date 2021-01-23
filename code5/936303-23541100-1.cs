    [Route("/checkout/{Id}")]
    public class Checkout : IReturn<CheckoutResponse>
    {
       public int Id { get; set; }
       public String Title { get; set; }
       public String Foo { get; set; }
    }
