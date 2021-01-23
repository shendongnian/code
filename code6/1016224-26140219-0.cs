            var start = new DateTime(2014, 09, 09);
            var end = new DateTime(2014, 10, 01);
            var listOfDays = new List<DateTime>();
            int i = 0;
            for (var day = start; day < end; day = day.AddDays(1))
            {
                listOfDays.Add(day);
            }
            Parallel.ForEach(listOfDays.ToArray(), currentDay =>
            {
                for (var d = new DateTime(currentDay.Year, currentDay.Month, currentDay.Day, 0, 0, 0); d < new DateTime(currentDay.Year, currentDay.Month, currentDay.Day, 23, 59, 59); d = d.AddSeconds(5))
                {
                    var str = "Loop: " + i + ", Date: " + d.ToString();
                    Console.WriteLine(str);
                }
                i++;
                
            });
            Console.Read();
