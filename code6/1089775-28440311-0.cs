        while (counterH < height)
        {
            Console.Write("|");
            int counterW3 = 0;
            while (counterW3 < width)
            {
                Console.Write(" ");
                counterW3++;
            }
            Console.Write("|" + System.Environment.NewLine);
            counterH++;
        }
