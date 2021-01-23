    /// <summary>
    /// Searches for the first file matching to searchPattern in the sepcified path.
    /// </summary>
    /// <param name="path">The path from where to start the search.</param>
    /// <param name="searchPattern">The pattern for which files to search for.</param>
    /// <returns>Either the complete path including filename of the first file found
    /// or string.Empty if no matching file could be found.</returns>
    public static string FindFirstFile(string path, string searchPattern)
    {
        string[] files;
        try
        {
            // Exception could occur due to insufficient permission.
            files = Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
        }
        catch (Exception)
        {
            return string.Empty;
        }
        // If matching files have been found, return the first one.
        if (files.Length > 0)
        {
            return files[0];
        }
        else
        {
            // Otherwise find all directories.
            string[] directories;
            try
            {
                // Exception could occur due to insufficient permission.
                directories = Directory.GetDirectories(path);
            }
            catch (Exception)
            {
                return string.Empty;
            }
            // Iterate through each directory and call the method recursivly.
            foreach (string directory in directories)
            {
                string file = FindFirstFile(directory, searchPattern);
                // If we found a file, return it (and break the recursion).
                if (file != string.Empty)
                {
                    return file;
                }
            }
        }
        // If no file was found (neither in this directory nor in the child directories)
        // simply return string.Empty.
        return string.Empty;
    }
