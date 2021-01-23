    public void CloneAndEnumerateCommitsFromHead()
    {
        var tmp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
    
        string path = Repository.Clone(
            "https://github.com/nulltoken/TestGitRepository", 
            tmp,
            onTransferProgress: ProgressHandler);
    
        using (var Git = new Repository(path))
        {
            foreach (var Commit in Git.Commits)
            {
                Console.WriteLine("{0} by {1}",
                    Commit.Id.ToString(7),
                    Commit.Author.Name);
            }
        }
    }
    
    private int ProgressHandler(TransferProgress progress)
    {
        Console.WriteLine("{0}/{1}", progress.IndexedObjects, progress.TotalObjects);
        return 0;
    }
