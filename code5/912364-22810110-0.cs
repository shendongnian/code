            Console.WriteLine("Choose 7 numbers (1-39) by pressing ENTER after every number:");
            string data = Console.ReadLine();
            int[] userLottery = new int[7];
            int i = 0;
            StringBuilder num = new StringBuilder();
            foreach (char item in data)
            {
                
                if (!Char.IsDigit(item))
                {
                    if (num.Length == 0)
                        continue;
                    userLottery[i] = int.Parse(num.ToString());
                    i++;
                    num.Clear();
                    continue;
                }
                num.Append(item);
            }
            if(num.Length > 0)
                userLottery[i] = int.Parse(num.ToString());
