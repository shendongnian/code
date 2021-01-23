    string ARG1  = "DATABASE"; string ARG2 = "3,2,3";
    int previous = 0;
    string[] sizeSplit = ARG2.Split(',');
    for (int i = 0; i < sizeSplit.Length; i++)
    {
        string eachNumber = sizeSplit[i];
        int j = Int32.Parse(eachNumber);
            
        string splitString = ARG1.Substring(previous, j);
        previous +=j;
        seperatedWord.Add(splitString);
    }
