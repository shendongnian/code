    class Critter
    {
        public string Name { get; set; }
        public int Hunger = 0;
        public int Boredom = 0;
        public string m = "Happy";
       // No Change in PassTime() method and  mood() method
       //
        public void talk()
        {
            Console.WriteLine("I'm", Name, "and I feel", m, "now.\n");
            PassTime();
        } 
