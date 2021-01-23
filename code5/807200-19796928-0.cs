        const int bufsize = 4096;
        int lineCount = 0;
        Byte[] buffer = new Byte[bufsize];
        using (System.IO.FileStream fs = new System.IO.FileStream(@"C:\\data\\log\\20111018.txt", FileMode.Open, FileAccess.Read, FileShare.None, bufsize))
        {
            int totalBytesRead = 0;
            int bytesRead;
            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0) {
                int i = 0;
                while (i < bytesRead)
                {
                    switch (buffer[i])
                    {
                        case 10:
                            {
                                lineCount++;
                                i++;
                                break;
                            }
                        case 13:
                            {
                                int index = i + 1;
                                if (index < bytesRead)
                                {
                                    if (buffer[index] == 10)
                                    {
                                        lineCount++;
                                        i += 2;
                                    }
                                }
                                else
                                {
                                    i++;
                                }
                                break;
                            }
                        default:
                            {
                                i++;
                                break;
                            }
                    }
                }
                totalBytesRead += bytesRead;
            }
            if ((totalBytesRead > 0) && (lineCount == 0))
                lineCount++;                    
        }
