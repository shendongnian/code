    class Dice
    {
        private Random randy;               
        private int total;
        private static const int NUM_SIDES = 6;
        private int[] counts;
        public Dice()
        {
            randy = new Random();
            counts = new int[ NUM_SIDES ];
        }
        public static void Main()
        {
            Dice myDice = new Dice();
            Console.Clear();                
            int throws = myDice.manyThrow(); // need to save the number of throws
            myDice.throwDice( throws );
            countEm();
            Console.ReadKey();
        }
        public void throwDice( int throws )
        {
            double count = 0;
            while(count != throws)
            {
                count++;
                int result = oneThrow();
                counts[ result - 1 ]++; // NOTE: result-1 because arrays are 0-based.
                Console.WriteLine("Throw No " + count + " is " + oneThrow());    
            }
        }
        // ...
        public void countEm()
        {
            for( int i = 0; i < counts.Count; ++i )
                Console.WriteLine( (i+1) + " thrown " + counts[i] + " times." );
        }
