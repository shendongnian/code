        public struct TimeValue
        {
            public DateTime time {get;set;}
            public int value{get;set;}
        }
        static void Main(string[] args)
        {
            var txt = @"12/31/2013 10:00:01  96
            12/31/2013 10:00:02  20
            12/31/2013 10:00:03  51
            12/31/2013 10:00:04  62
            12/31/2013 10:00:05  84
            12/31/2013 10:00:06  78
            12/31/2013 10:00:07  74
            12/31/2013 10:00:08 150
            12/31/2013 10:00:09 130
            12/31/2013 10:00:10  99
            12/31/2013 10:00:11 101
            12/31/2013 10:00:12 123
            12/31/2013 10:00:13  51
            12/31/2013 10:00:14  61
            12/31/2013 10:00:15  19
            12/31/2013 10:00:16  81
            12/31/2013 10:00:17  98
            12/31/2013 10:00:18  39
            12/31/2013 10:00:19  45
            12/31/2013 10:00:20  65";
            var values = 
                (from line in txt.Split(new[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                let pair = line.Split(new[]{' '}, 3, StringSplitOptions.RemoveEmptyEntries)
                select new TimeValue
                {
                    time = DateTime.ParseExact(pair[0] + " " + pair[1], "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    value = int.Parse(pair[2])
                })
                .OrderBy(e => e.time)
                .ToArray();;
            TimeSpan range = TimeSpan.FromSeconds(5);
            
            int totalMax = -1;
            int maxTail = -1;
            int maxHead = -1;
            int tail = 0; // index at tail of the window
            int currentMax = 0;
            for (int head = 0; head < values.Length; head++) // head of the window
            {
                currentMax += values[head].value; // add next value
                DateTime tailTime = values[head].time - range;
                while (values[tail].time <= tailTime) // remove values at tail that don't fit in range
                {
                    currentMax -= values[tail].value;
                    tail++;
                }
                if (currentMax > totalMax)
                {
                    totalMax = currentMax;
                    maxTail = tail;
                    maxHead = head;
                }
            }
            Console.WriteLine("Maximum range from times:" + values[maxTail].time + " - " + values[maxHead].time);
        }
