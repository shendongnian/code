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
            Console.Write("Lions and Tigers like zebras");
        }
    } 
