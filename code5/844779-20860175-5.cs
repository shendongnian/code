            foreach (music iMusic in pMusic)
            {
                using (TagLib.File file = TagLib.File.Create(iMusic.path))
                {
                    System.Diagnostics.Debug.WriteLine(
                            file.Properties.Duration.ToString(@"hh\:mm\:ss"));
                }
            }
