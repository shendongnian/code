    private static void OnChanged(object source, FileSystemEventArgs e)
	{
			//set EnableRaisingEvents = false at the start of the method.
			FileSystemWatcher t = source as FileSystemWatcher;
            t.EnableRaisingEvents = false;
            //do stuff that you want in the method, in my case checking for words.	
            .... 
            ....
            //Set EnableRaisintEvents true again
			t.EnableRaisingEvents = true;
			
	}
