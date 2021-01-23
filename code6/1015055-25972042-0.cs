    List<string> doubleList = new List<string>(new string[]
            {
                "12345",
                "1234.5",
                "123.45",
                "12.345",
                "1.2345",
                "1.2",
                "1.23",
                "1.234",
                "1.23.45",
                "12.3",
                "123.4",
            }) { };
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var x in doubleList)
            {
                int countNumber = Regex.Matches(x, @"[0-9]").Count;
                int countOfDot = Regex.Matches(x, @"\.").Count;
                if (countOfDot == 1 && countNumber != 0) //contains "." and any digit
                {
                    Console.WriteLine(x);
                }
                else if (countOfDot == 0 && countNumber != 0) //not contains "." and any digit
                {
                     Console.WriteLine(x);
                }
                else
                {
                   //do nothing . . .
                }
            }
        }
