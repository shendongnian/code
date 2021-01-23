    Train train;
    foreach(object t in trains)
    {
        if ((train = t as Train) != null)
        {
            Console.WriteLine(t.Number); 
            Console.WriteLine(t.Destination);
        }
    }
