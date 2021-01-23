                byte[] bytes = new byte[numBytesToRead];
                //...
                List<FileInfo> objFileInfo = new List<FileInfo>();
                //...
                //...
                while (numBytesToRead > 0)
                {
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                    //First time here bytes[0] == the first byte of the file
                    //Second time here bytes[0] == 10000th byte of file
                    //...
                    //The following line should copy the bytes into file info instead of the reference to the existing byte array
                    fileInfo = new FileInfo { ..., FileBytes = bytes, ... };
                    objFileInfo.Add(fileInfo);
                    //First time here objFileInfo[0].FileBytes[0] == first byte of file
                    //Second time here objFileInfo[0].FileBytes[0] == 10000th byte of file because objFileInfo[All].FileBytes == bytes
                    //...
                }
