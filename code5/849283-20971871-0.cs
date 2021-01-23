    interface Lion
    {
        void EatZebra();
    }
    interface Tiger
    {
        void EatZebra();
    }
    class CatAnimal : Lion, Tiger
    {
        public void EatZebra()
        {
            System.Console.WriteLine("I like zebras");
        }
    } 
