    namespace CodingFun
    {
        using System;
        using System.IO;
        using System.Threading;
    
        /// <summary>
        /// Represents our FileAccessHelper class.
        /// </summary>
        public static class FileAccessHelper
        {
            /// <summary>
            /// Blocks until the specified file can be accessed or a timeout occurs.
            /// </summary>
            /// <param name="filename">The file which shall be accessed.</param>
            /// <param name="timeout">The timeout in milliseconds.</param>
            /// <param name="accessMode">Specifies the file access mode, default is read only.</param>
            public static void WaitForFileAccessibility(string filename, int timeout, FileAccess accessMode = FileAccess.Read)
            {
                int tries = 0;
                bool readDone = false;
    
                do
                {
                    try
                    {
                        // Try to open the file as read only.
                        FileStream fs = File.Open(filename, FileMode.Open, accessMode);
    
                        // Close it if it worked and...
                        fs.Close();
    
                        // ... set a flag so that we know we have successfully opened the file.
                        readDone = true;
                    }
                    catch (Exception e)
                    {
                        // increase the counter and...
                        tries++;
    
                        // ... check if a timeout occured.
                        if ((100 * tries) >= timeout)
                        {
                            throw new FileAccessHelperException(string.Format("Unable to access the file {0} within the specified timeout of {1}ms", filename, timeout), e);
                        }
                        else
                        {
                            // If not just sleep 100 ms.
                            Thread.Sleep(100);
                        }
                    }
                }
                while (!readDone);
            }
        }
    }
