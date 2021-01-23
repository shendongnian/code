    //file1 and file2 are MemoryStream or file names
    //for performance reason it is better that file1 is less than file2
    //file1.Position = 0;//ensure at case of MemoryStream
    using (var zip1 = ZipFile.Read(file1))
    {
        //file2.Position = 0;//ensure at case of MemoryStream
    	using (var zip2 = ZipFile.Read(file2))
    	{
    		var zip2EntryNames = zip2.Entries.Select(y => y.FileName).ToList();
    		foreach (var entry in zip1.Entries.Where(x => !zip2EntryNames.Contains(x.FileName)).ToList())
    		{
    			var memoryStream = new MemoryStream();
    			entry.Extract(memoryStream);
    			memoryStream.Position = 0;
    			zip2.AddEntry(entry.FileName, memoryStream);
    		}
            if(save2file)
                zip2.Save(fileNameResult);
            else
         		using (var result = new MemoryStream())
    	    	{
        			zip2.Save(result);                        
        		}
    	}
    }
