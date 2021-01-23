    bool allOne = true;
    for (int x = 0; x < bitstrings.Length; x++)
    {
        //3 instead of 4 because arrays are 0 indexed
        if(bitstrings[x][3] != '1')
        {
           allOne = false;
           break;
        }
    }
    if(allOne)
    { 
       //Do something
    }
    Console.ReadLine(); 
