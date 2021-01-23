        // creating
        var q = new RecentQueue<Transaction>(TimeSpan.FromDays(360)); // last 360 days
        var q = new RecentQueue<Transaction>(TimeSpan.FromSeconds(5)) // last 5 seconds
        // adding elements
        var t = new Transaction { Category = "cat1", TotalCost = "5",
                                    TotalEarned = "3", TotalHST = "2" }
        q.Enqueue(t);
        // iterating 
        foreach (var element in q)
            // do whatever
