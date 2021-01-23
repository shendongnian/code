    int idLength = 3;
    string evidence = //read from file
    List<string> suspects = //read from file
    List<double> matchScores = new List<double>();
    foreach (string suspect in suspects)
    {
        int count = 0;
        for (int i = idLength; i < suspect.Length; i++)
        {
            if (suspect[i + idLength] == evidence[i]) count++;
        }
        matchScores.Add(count * 100 / evidence.Length);
    }
    
