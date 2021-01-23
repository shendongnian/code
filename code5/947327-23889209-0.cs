    int total = theList.Count;
    int done = 0;
    foreach (var item in theList)
    {
    	Process(item);
    	done++;
    	
    	// Outputs progress
    	double percentage = done / total * 100;
    	Console.WriteLine(percentage);
    }
