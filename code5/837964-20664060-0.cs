        string file = "_" + num;
        
        SoundPlayer sp;
        Stream s = Properties.Resources.ResourceManager.GetStream(file);
        if (s != null)
        {
            sp = new System.Media.SoundPlayer(s);
            sp.Play();
        }
