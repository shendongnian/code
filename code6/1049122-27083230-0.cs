    string[] first = System.IO.File.ReadAllLines("path of first txt file");
    string[] second = System.IO.File.ReadAllLines("path of second txt file");
    
    var sb = new StringBuilder();
    
    
    for(int i = 0; i < first.Lenght; i++)
    {
    	for(int j = 0; j < second.Lenght; j++)
    	{
    		if (i != 0 && i % 5 == 0)
    		{
    			sb.Append(second[j] + "\n");
    		}
    		else
    		{
    			sb.Append(first[i] + "\n");
    			continue;
    		}
    	}
    }
    
    
    // create new txt file
    var file = new System.IO.StreamWriter("path of third txt file");
    file.WriteLine(sb.ToString());
