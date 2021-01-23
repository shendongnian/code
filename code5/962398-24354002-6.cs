    class Program
    {
        static void Main()
        {
           Order ord = new Order(); 
           //customer ordered for country special
           ord.PlaceOrder(new CountrySpecial()); //this will call bake of CountrySpecial
           //maybe some other customer ordered for different pizza, and we can change at run-time(thanks to our design!)
           ord.PlaceOrder(new FarmHouse()); // this will call Bake of FarmHouse
           
        }
    }
