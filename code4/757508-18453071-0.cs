    string repoPath = "path/to/your/repo";
    
    // Create a temp folder for a second working directory
    string tempWorkDir = Path.Combine(Path.GetTempPath(), "tmp_wd");
    Directory.CreateDirectory(newWorkdir);
    
    // Also create a new index to not alter the main repository
    string tempIndex = Path.Combine(Path.GetTempPath(), "tmp_idx");
    
    var opts = new RepositoryOptions
    {
        WorkingDirectoryPath = tempWorkDir,
        IndexPath = tempIndex
    };
    
    using (var mainRepo = new Repository(repoPath))
    using (var otherRepo = new Repository(mainRepo.Info.Path, opts))
    {
        string path = "file.txt";
    
        // Do your stuff with mainrepo
        mainRepo.CheckoutPaths("HEAD", new[] { path });
        var currentVersion = File.ReadAllText(Path.Combine(mainRepo.Info.WorkingDirectory, path));
    
        // Use otherRepo to temporarily checkout previous versions of files
        // Thank to the passed in RepositoryOptions, this checkout will not
        // alter the workdir nor the index of the main repository.
        otherRepo.CheckoutPaths("HEAD~2", new [] { path });
        var olderVersion = File.ReadAllText(Path.Combine(otherRepo.Info.WorkingDirectory, path));
    }
