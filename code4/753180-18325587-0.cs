    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace Copy
    {
        class CopyDirTimestamps
        {
            public static bool CopyTimestamps(
                string sourceDirName, string destDirName, bool copySubDirs)
            {
                try
                {
                    CopyForDir(sourceDirName, destDirName, copySubDirs, false);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
    
    
            private static void CopyForDir(
                string sourceDirName, string destDirName, bool copySubDirs, bool isSubDir)
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();
    
                // If the source directory does not exist, throw an exception.
                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }
    
                if (!Directory.Exists(destDirName)) return;
    
                DirectoryInfo destDir = new DirectoryInfo(destDirName);
    
                // If copySubDirs is true, copy the subdirectories.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        // Create the subdirectory.
                        string temppath = Path.Combine(destDirName, subdir.Name);
    
                        // Copy the subdirectories.
                        CopyForDir(subdir.FullName, temppath, copySubDirs, true);
                    }
                }
    
                if (isSubDir)
                {
                    destDir.CreationTime = dir.CreationTime;
                    destDir.LastAccessTime = dir.LastAccessTime;
                    destDir.LastWriteTime = dir.LastWriteTime;
                }
            }
        }
    }
