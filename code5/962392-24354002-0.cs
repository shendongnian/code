    class Program
    {
        static void Main()
        {
           Order ord = new Order(); //customer ordered for country special
           ord.PlaceOrder(new CountrySpecial());
           //can change at run time, maybe some other customer ordered for different
           ord.PlaceOrder(new FarmHouse());
           
        }
    }
