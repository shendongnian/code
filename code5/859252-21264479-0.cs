    List<string> listOfFiles = new List<string>();
            List<string> processedNames = new List<string>();
            foreach (string file in Directory.GetFiles("pathtofiles/"))
            {
                // Add to files list.
                listOfFiles.Add(file);
            }
            // Run through each file and get all that match.
            foreach (string file in listOfFiles)
            {
                // Get fileName.
                string fileName = file.Split('.')[0];
                if (!processedNames.Contains(fileName))
                {
                    // All files from this point will be the same (but with the different extensions).
                    // get all file names like this.
                    foreach (string matchingFile in listOfFiles.Where((s) => s.StartsWith(fileName + ".")))
                    {
                        // This file matches the one we just got.
                    }
                    // Set that we have processed this fileName.
                    processedNames.Add(fileName);
                    // We now start a new set of Files.
                }
            }
