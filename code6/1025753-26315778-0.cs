    string[] nameArray = names.ToArray();
    
    for(int z = 0;z < nameArray.Length;z++)
    {
        for (int y = 0; y < nameArray.Length; y++)
        {
            if (nameArray[y] == nameArray[z])
            {
                Console.WriteLine("The name: "+ nameArray[y]+" is a duplicate.");
            }
    
        }
    
    }
