    public static void Main(string[] args)
    {
        List<int> notes = new List<int>();
        List<int> amounts = new List<int>() { 50,100,200 };
        Change(notes, amounts, 0, 0, 250);
    }
    
    static void Change(List<int> notes, List<int> amounts, int highest, int sum, int goal)
    {
        //
        // See if we are done.
        //
        if (sum == goal)
        {
            Display(notes, amounts);
            return;
        }
        //
        // See if we have too much.
        //
        if (sum > goal)
        {
            return;
        }
        //
        // Loop through amounts.
        //
        foreach (int value in amounts)
        {
            //
            // Only add higher or equal amounts.
            //
            if (value >= highest)
            {
            List<int> copy = new List<int>(notes);
            copy.Add(value);
            Change(copy, amounts, value, sum + value, goal);
            }
        }
    }
