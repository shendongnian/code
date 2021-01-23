    void Main()
    {
    	using(StreamWriter writer = new StreamWriter("D:\\Test.txt", true))
    	{
    		while(true)
    		{
    			writer.WriteLine("Test");
    		}
    	}
 
        // At some point, stop the writing and comment it out and then re-execute with 
        // with the reading code below. I ran the above until I had a 10GB text file.     
 
    	using (TextReader reader = new StreamReader(File.Open("D:\\Test.txt", 
                                                    FileMode.Open, FileAccess.Read, 
                                                    FileShare.ReadWrite)))
    	{
    		while(true) 
    		{
    			var line = string.Empty;
    			while((line = reader.ReadLine()) == null)
    			{
    				Console.WriteLine("Waiting....");
    				Thread.Sleep(500);
    			}
    			
    			Console.WriteLine(line);
    		}
    	}
    }
