    using (var repo = new Repository(BareTestRepoPath))
    {
        var commit = repo.Lookup<Commit>("deadbeefcafe"); // or any other way to retreive a specific commit
        var treeEntry = commit["path/to/my/file.txt");
        Debug.Assert(treeEntry.TargetType == TreeEntryTargetType.Blob);
        var blob = (Blob)treeEntry.Target;
        var contentStream = blob.GetContentStream();
        Assert.Equal(blob.Size, contentStream.Length);
        using (var tr = new StreamReader(contentStream, Encoding.UTF8))
        {
            string content = tr.ReadToEnd();
            Assert.Equal("hey there\n", content);
        }
    }
