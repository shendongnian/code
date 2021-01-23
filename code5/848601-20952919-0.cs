    for (int i = 0; i < 10; i++)
            {
                var newDate = DateTime.Now.AddDays(-i);
                Console.WriteLine(newDate.Day + " " + newDate.Month);
            }
