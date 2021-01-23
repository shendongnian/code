            DateTime d1 = new DateTime(2014, 5, 1, 7, 10, 0);
            DateTime d2 = new DateTime(2014, 5, 30, 7, 20, 0);
            while (d1.CompareTo(d2) < 0)
            {
                Console.WriteLine(d1 + " -- " + d1.AddDays(1).AddMinutes(10));
                d1 = d1.AddDays(1);
            }
