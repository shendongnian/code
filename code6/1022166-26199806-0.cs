            Console.WriteLine("How much money do you want to play with?");
            bool itsNumeric = false;
            double money;
            while(itsNumeric == false)
            {
                itsNumeric = double.TryParse(Console.ReadLine().ToString(), out money);
            }                
