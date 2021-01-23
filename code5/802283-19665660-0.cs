         while (true)
            {
                Console.Write("Enter your number: ");
                double temp = Convert.ToDouble(Console.ReadLine());
                if (myList.Sum() + temp <= 100)
                {
                    myList.Add(temp);
                    if (myList.Sum() >= 100)
                    {
                        break;
                    }
                }
                else
                {
                    Console.Write("You Exceed The Limit ");
                }
            }
