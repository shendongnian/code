    public void Display()
    {
        ...
        for (int i = 0; i<trains.Count; i++)
        {
            Train myTrain = (Train)trains[i];
            Console.WriteLine(myTrain.Number); 
            Console.WriteLine(myTrain.Destination);
        } 
    }
