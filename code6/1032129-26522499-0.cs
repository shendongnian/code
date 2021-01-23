    private void CreateAnimatedGif(bool ToCreate) {
        string dateOfCreate;
    
        if (ToCreate == false)
        {
            if(AnimatedGifFiles.Count == 0) // that means it's the first element in the list
            {
                dateOfCreate = DateTime.Now.ToString();
            }
            AnimatedGifFiles.Add(last_file);
        }
        else
        {
            if(AnimatedGifFiles.Count == 0) // that means it's the first element in the list
            {
                dateOfCreate = DateTime.Now.ToString();
            }
            if (!AnimatedGifFiles.Contains(last_file))
            {
                AnimatedGifFiles.Add(last_file);
            }
            if (AnimatedGifFiles.Count > 1)
            {
                unfreezWrapper1.MakeGIF(AnimatedGifFiles, AnimatedGifDirectory + dateOfCreate +   DateTime.Now.ToString(), 80, true);
            }
            AnimatedGifFiles = new List<string>();
        } }
