        public string BLoop()
        {
            string sStatus = "Process Started";
            Console.WriteLine(sStatus);
            for (int i = 99; i > 0; i--)
            {
                Console.WriteLine(string.Format("{0} bottles of beer on the wall, {0}   bottles of beer.", i));
                Console.WriteLine(string.Format("Take one down, pass it around, {1} bottles of beer on the wall.", i, i - 1));
                Console.WriteLine();
            }
            sStatus = "Process Completed";
            return sStatus;
        }
