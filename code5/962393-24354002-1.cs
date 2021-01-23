    interface IPizza {    
        public String Bake();  }  
    
    public class CoutrySpecialPizza: IPizza   {
         public String Bake() 
         {
          //add country special toppings 
         } }
    
    public class FarmHouse: IPizza   {
         public String Bake()
         { 
         //add farm house special toppings 
         } }
    
    public class Order   {
        public void PlaceOrder(IPizza pizza) 
        {
         pizza.Bake(); 
         //pack and ship 
        } }
