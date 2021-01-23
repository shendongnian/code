    /// <summary>
    /// Container for any bad files that fail during import
    /// </summary>
    public static List<ImportItem> badFiles = new List<ImportItem>();
    /// <summary>
    /// Imports a list of files
    /// </summary>
    /// <param name="files">The list of files to import</param>
    /// <param name="chunkSize">The number of files to try to import at one time</param>
    public static void ImportFiles(List<ImportItem> files, int chunkSize)
    {
        if (files == null || files.Count == 0) return;   
         
        int startIndex = 0; // Start from the beginning of the list
        while (startIndex < files.Count)
        {
            // Adjust chunkSize in case we're trying to get 
            // more files from the list than it contains
            if (chunkSize + startIndex > files.Count)
            {
                chunkSize = files.Count - startIndex;
            }
            // Get the next 'chunk' of files to import
            List<ImportItem> filesChunk = files.GetRange(startIndex, chunkSize);
            try
            {
                // Import the chunk of files
                ImportFilesChunk(filesChunk);
            }
            catch
            {
                // At least one of the files in this chunk failed
                if (filesChunk.Count == 1)
                {
                    // We're down to one file, so add it to
                    // the 'bad files' list and continue on
                    badFiles.Add(filesChunk[0]);
                }
                else
                {
                    // Use a smaller chunk size to split this chunk further
                    var newChunkSize = (chunkSize / 2) + (chunkSize % 2); // Round up if chunkSize is odd
                    ImportFiles(filesChunk, newChunkSize);
                }
            }
            finally
            {
                // Move start position to the position just 
                // after the chunk we just processed
                startIndex += chunkSize;
            }
        }
    }
