    class Program
    {
        static void Main()
        {
           Order ord = new Order(); //customer ordered for country special
           ord.PlaceOrder(new CountrySpecial()); //this will call bake of CountrySpecial
           //can change at run time, maybe some other customer ordered for different
           ord.PlaceOrder(new FarmHouse()); // this will call Bake of FarmHouse
           
        }
    }
