    pubic class Program
    {
        public System.Random ran = new System.Random();
        public int power;
        public Program()
        {
           power = ran.Next(0, 10);
        }
    }
