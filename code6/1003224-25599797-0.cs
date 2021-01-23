    string trgd = "D:\\trrnd.txt";
	if(File.Exists(trgd))
	{
		var dt = File.GetCreationTimeUtc(trgd);
		if((dt - DateTime.UtcNow).Hour > 24)
		{
            //Overwrite existing file
			File.WriteAllLines(trgd,"Some new text");
		}
	}
	else
	{
        //append to existing file
		File.AppendAllText(trgd,"Some Text");
	}
