    private List<string> AnimatedGifFiles;
    private  DateTime startTime;  // new!!
    
    private void CreateAnimatedGif(bool ToCreate)
    {
        if(AnimatedGifFiles.Count == 0)   // new!!
          startTime = DateTime.Now;
        if (ToCreate == false)
        {
            AnimatedGifFiles.Add(last_file);
        }
        else
        {
            for (int i = 0; i < AnimatedGifFiles.Count; i++)
            {
                if (!AnimatedGifFiles[i].Contains(last_file))
                    AnimatedGifFiles.Add(last_file);
            }
            if (AnimatedGifFiles.Count > 1)
            {
                string outputFile = System.IO.Path.Combine(   // new!!
                    AnimatedGifDirectory, 
                    string.Format(
                        System.Globalization.CultureInfo.InvariantCulture, 
                        "Event-{0:yyyy-MM-dd}-{1:yyyy-MM-dd}.gif", startTime, DateTime.Now)); 
                    
                unfreezWrapper1.MakeGIF(AnimatedGifFiles, outputFile, 80, true); //new!!
            }
            AnimatedGifFiles = new List<string>();
        }
    }
