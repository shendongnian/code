    foreach (string s in sa){
        if (string.IsNullOrEmpty(s))
        {
           continue;
        }
    	using (FileStream fileStream = System.IO.File.Open(s, FileMode.Open))
    	{
    		if (frame == 0){
    			pages = (Bitmap)Image.FromStream(fileStream);
    			//save the first frame
    		}
    		else{
    			//save the intermediate frames
    		}
    		if (frame == sa.Length - 1)
    		{
    			//flush and close.
    		}
    		frame++;
    	}
    }
