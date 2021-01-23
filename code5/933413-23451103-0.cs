    void Main()
    {
    	var empty_object = new MyObject();
    	
    	var initialzied_object = new MyObject() {
    		  SellPricePerKey = 70, // cena klucza w scrapach np. 31 / 9 = 3.55 ref
    		  BuyPricePerKey  = 69, // cena klucza w scrapach np e.g. 29 / 9 = 3.33 ref
    		  SellPricePerTod = 33,// cena ToD'a w scrapach np. 31 / 9 = 3.55 ref
    		  BuyPricePerTod  = 28 // c
    	};
    	
    	
    	initialzied_object	.Dump("Initialized object value:");
    	
    	var j_empty_object = Newtonsoft.Json.JsonConvert.SerializeObject(initialzied_object);
    
    }
    
    // Define other methods and classes here
    
    public class MyObject {
    	public	int SellPricePerKey ;
    	public  int BuyPricePerKey;
    	public	int SellPricePerTod ;
    	public	int BuyPricePerTod;
    }
