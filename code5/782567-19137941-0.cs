        /// <summary>
        /// Finds the text files that contain paragraph.
        /// </summary>
        /// <param name="paragraph">The paragraph to check for.</param>
        /// <param name="textFilePaths">A list of paths to text files to check.</param>
        /// <returns></returns>
        List<string> FindFilesWithParagraph(string paragraph, List<string> textFilePaths)
        {
            List<string> foundPaths = new List<string>(); // list of paths to text files w/ paragraph
            foreach (string path in textFilePaths) // iterate through each file
            {
                if (!File.Exists(path)) // check files actually exist
                    throw new ArgumentException();
                using (var sr = new System.IO.StreamReader(path))
                {
                    if (sr.ReadToEnd().Contains(paragraph)) // read contents of file
                        foundPaths.Add(path); // and add it to list if it contains the paragraph
                }
            }
            return foundPaths;
        }
