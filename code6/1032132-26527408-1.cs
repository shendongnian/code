    private string startDateTime = "";
    private void CreateAnimatedGif(bool ToCreate)
    {
        string endDateTime; 
    
        if (ToCreate == false)
        {
            if(startDateTime != ""){startDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH'h'mm'm'ss's'_");}
            AnimatedGifFiles.Add(last_file);
        }
        else
        {
            if (!AnimatedGifFiles.Contains(last_file))
            {
                AnimatedGifFiles.Add(last_file);
            }
            if (AnimatedGifFiles.Count > 1)
            {
                endDateTime = DateTime.Now.ToString("_yyyy-MM-ddTHH'h'mm'm'ss's.gif'");
                unfreezWrapper1.MakeGIF(AnimatedGifFiles, startDateTime + AnimatedGifDirectory + endDateTime, 80, true);
            }
            startDateTime = "";
            if(AnimatedGifFiles.Count != 0){AnimatedGifFiles.Clear();}
        }
    }
