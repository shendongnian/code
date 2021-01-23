    ServerManager mgr = new ServerManager();
        //Sites
        foreach(Site s in mgr.Sites)
        {
            //Applications
            foreach(Application app in s.Applications)
            {
                //Virtual Directories
                foreach(VirtualDirectory virtDir in app.VirtualDirectories)
                {
                    
                }
            }
        }
