    int index = 0;
    for (int i = 0; i < sizeSplit.Length; i++)
    {
         string eachNumber = sizeSplit[i];
         int j = Int32.Parse(eachNumber);         
         string splitString = pattern.Substring(index,j);
         index += j;
         seperatedWord.Add(splitString);
    }
