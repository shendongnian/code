    int maxIndex = -1;
    int max = -1;
    
    for (int i = 0; i < numOfCandidates.Length; i++)
    {
        Console.WriteLine("Enter a Candidate Name");
        candidateName[i] = Console.ReadLine();
        Console.WriteLine("Enter number of votes thus far");
        int num = int.Parse(Console.ReadLine()); // <-- unsafe
        // just check it every time, if the number is greater than the previous maximum, update it.
        if (num > max)
        {
           max = num;
           maxIndex = i;
        }
        numOfVotes[i] = num;
    }
    
    Console.WriteLine("Candidate {0}, with {1} votes, has the most votes", candidateName[maxIndex], max);
