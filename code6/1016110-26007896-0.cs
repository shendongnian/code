            int num = 0;
            bool isValid = false;
            do
            {
                Console.Write("Please enter 4 digits to encrypt: ");
                string numstr = Console.ReadLine();
                if (numstr.Length == 4)
                {
                    isValid = Char.IsDigit(numstr[0]) && Char.IsDigit(numstr[1]) 
                           && Char.IsDigit(numstr[2]) && Char.IsDigit(numstr[3]);
                }
                if (isValid)
                    num = Convert.ToInt32(input);
            }
            while (!isValid);
