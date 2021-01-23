                    UltraID3 mFile = new UltraID3();
                    //FileInfo fInfo;
                    mFile.Read(item);
                    //fInfo = new FileInfo(item);
                    bool onDevice = true;
                    if (DeviceMusic.Contains(item))
                    {
                        onDevice = false;
                    }
                    // My Problem starts here
                    lstMusicInfo.Add(new MediaFile()
                    {
                        Title = mFile.Title,
                        Album = mFile.Album,
                        Year = mFile.Year.ToString(),
                        ComDirectory = Path.GetDirectoryName(item), // fInfo.Directory.FullName,
                        FileFullName = Path.GetFileName(item), //fInfo.FullName,
                        Artist = mFile.Artist,
                        OnDevice = onDevice,
                        PTDevice = false
                    });
                    //Ends here.
