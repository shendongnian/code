    void Main()
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
        var data = 
            (from line in txt.Split(new[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
            let pair = line.Split(new[]{' '}, 3, StringSplitOptions.RemoveEmptyEntries)
            select new Entry
            {
                dt = DateTime.Parse(pair[0] + " " + pair[1]),
                val = int.Parse(pair[2])
            })
            .OrderBy(e => e.dt);
        
        var range = TimeSpan.FromSeconds(5);
        var queue = new Queue<Entry>();
        int max = 0;
        DateTime? maxStart = null;
        DateTime? maxEnd = null;
        int sum = 0;
        
        foreach (var entry in data)
        {
            queue.Enqueue(entry);
            sum += entry.val;
            while(queue.Count > 0 && entry.dt - queue.Peek().dt >= range)
            {
                sum -= queue.Dequeue().val;
            }
            if(sum > max)
            {
                max = sum;
                maxStart = queue.Peek().dt;
                maxEnd = entry.dt;
            }
        }
        Console.WriteLine("Max is {0}, between {1} and {2}", max, maxStart, maxEnd);
    }
    
    public class Entry
    {
        public DateTime dt;
        public int val;
    }
