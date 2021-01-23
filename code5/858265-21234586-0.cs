            Console.WriteLine("Enter a number:");
            char[] enteredNumber = Console.ReadLine().ToArray();
            int finalNumber = 0;
            for (int i = 0; i < enteredNumber.Count(); i++)
            {
                if (i % 2 != 0)//This condition might need tweeking
                { 
                    finalNumber = finalNumber + (Convert.ToInt32(enteredNumber[i].ToString()) * 2);
                }
                else
                {
                    finalNumber = finalNumber + Convert.ToInt32(enteredNumber[i].ToString());
                }
            }
            Console.WriteLine(finalNumber);
