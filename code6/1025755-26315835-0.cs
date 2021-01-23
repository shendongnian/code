    for(int z = 0;z < nameArray.Length;z++)
    {   
        int duplicates = 0;
        for (int y = z + 1; y < nameArray.Length - 1; y++)
        {
            if (nameArray[y] == nameArray[z])
            {
                duplicates++;
            }
        }
        Console.WriteLine("The name: "+ nameArray[y]+" is a duplicate " + duplicates + "times".);
    }
