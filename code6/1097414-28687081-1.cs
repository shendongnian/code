        List<String> folders = new List<string>(); // Assume your folders contai inside a List<>
        // Example with dummy data
        folders.Add("Testfolder1");
        folders.Add("Myfolder2");
        folders.Add("Testfolder3");
        folders.Add("Bestfolder4");
        folders.Add("Okayfolder8");
        // iterate through the List and extract folder names with certain string
        foreach (String item in folders)
        {
            if (item.Contains("Test"))
            {
                // Will only extract names which contains string Test
                Console.WriteLine(item);
            }
        }
