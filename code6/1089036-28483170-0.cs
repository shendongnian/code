    // add reference to Microsoft Shell controls and Automation
    // from the COM tab
    using Shell32;
    class ShellInfo
    {
          
        // "columns" we want:
        // FileName = 0;
        const int PerceivedType = 9;
        // FileKind = 11;
        // MediaBitrate = 28;
        // MediaLength = 27;
        static int[] info = {0, 9, 11, 27, 28};
        // note: author and title also available
        public static Dictionary<string, string> GetMediaProperties(string file)
        {
            Dictionary<string, string> xtd = new Dictionary<string, string>();
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder;
            folder = shell.NameSpace(Path.GetDirectoryName(file));
            foreach (var s in folder.Items())
            {
                if (folder.GetDetailsOf(s, 0).ToLowerInvariant() ==
                        Path.GetFileName(file).ToLowerInvariant())
                {
                    // see if it is video
                    // possibly check FileKind ???
                    if (folder.GetDetailsOf(s, PerceivedType).ToLowerInvariant() ==
                                    "video")
                    { 
                        // there are 35 known items
                        // add the ones we want using the int array of column indices 
                        foreach (int n in info)
                        {
                            xtd.Add(folder.GetDetailsOf(folder.Items(), n),
                                folder.GetDetailsOf(s, n));
                        }                 
                    }
                    break;
                }
                // ToDo:  freak out when it is not a video or audio type
                // depending what you are trying to do
            }
            return xtd;
                   
        }
    }
