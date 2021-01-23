            int maxPower = (int)Math.Log(int.MaxValue, 2); // 30 -> max power to not exceed int.MaxValue
            maxPower = (int)Math.Log(Math.Pow(2, maxPower) / number, 2); // prevent "NOTE1" > int.MaxValue
            for (int y = 0; y < maxPower; y++) // outputs all possible numbers; can be replaced with Random.Next(1, maxPower+1)
            {
                int sub = (int)Math.Pow(2, y);
                int x = number * sub; // NOTE1
                Console.WriteLine("{0} >> {1} = {2}", x, y, x >> y);
            }
