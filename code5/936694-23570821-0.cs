    private static List<string> foldersToSync = new List<string>(); // This will be populated with the items in "lstFoldersToSync" control on "Main" form.
    public static string folderToUpdate(string folderChanged)
    {
       // Main m = new Main();
        string folder1 = foldersToSync[0];
        string folder2 = foldersToSync[1];
        string folderToUpdate;
        // If the folder changed is folder1 then the folder to update must be folder2.
        // If the folder changed is folder2 then the folder to update must be folder1.
        if (folderChanged == folder1)
        {
            folderToUpdate = folder2;
        }
        else
        {
            folderToUpdate = folder1;
        }
        return folderToUpdate;
    }
