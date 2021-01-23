    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        if (Directory.Exists(sourceDirName))
        {
            cancontinue = true;
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            //Make an Array of Directories found on The Device
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            //Provide a Device Listing. Here is Where I am Stuck
            for (int i = 1; i < 11; i++)
            {
                string tmp =  destDirName + "\\Device\\ " + i.ToString();
                if ( ! Directory.Exists(tmp)) 
                {
                     Directory.CreateDirectory(tmp);
                     // !!!
                     // here apply your function to copy 
                     // from sourceDirName to directory in tmp variable
                     break;
                }
            }
        }
    }
