    using System;
    
    namespace ConsoleApplication1
    {
        class LootChooser
        {
            /// <summary>
            /// Choose a random loot type.
            /// </summary>
            public LootType Choose()
            {
                LootType lootType = 0;         // start at first one
                int randomValue = _rnd.Next(MaxProbability);
                while (_lootProbabilites[(int)lootType] <= randomValue)
                {
                    lootType++;         // next loot type
                }
                return lootType;
            }
			
            /// <summary>
            /// The loot types.
            /// </summary>
            public enum LootType
            {
                Bloodstone, Copper, Emeraldite, Gold, Heronite, Platinum,
                Shadownite, Silver, Soranite, Umbrarite, Cobalt, Iron, Default
            };
    
            /// <summary>
            /// Cumulative probabilities - each entry corresponds to the member of LootType in the corresponding position.
            /// </summary>
            protected int[] _lootProbabilites = new int[]
            {
                10, 77, 105, 125, 142, 159, 172, 200, 201, 202, 216, 282,  // (from the table in the answer - I used a spreadsheet to generate these)
                MaxProbability
            };
    
            /// <summary>
            /// The range of the probability values (dividing a value in _lootProbabilites by this would give a probability in the range 0..1).
            /// </summary>
            protected const int MaxProbability = 1000;
    
            protected Random _rnd = new Random((int)(DateTime.Now.Ticks & 0x7FFFFFFF));    
			
            /// <summary>
            /// Simple 'main' to demonstrate.
            /// </summary>
            /// <param name="args"></param>
            static void Main(string[] args)
            {
                var chooser = new LootChooser();
                for(int n=0; n < 100; n++)
                    Console.Out.WriteLine(chooser.Choose());
            }			
        }
    }
