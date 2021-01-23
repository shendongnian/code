    [Fact]
    public void CanRetrieveTwoVersionsOfTheSameBlob()
    {
        using (var repo = new Repository(BareTestRepoPath))
        {
            var c1 = repo.Lookup<Commit>("8496071");
            var b1 = c1["README"].Target as Blob;
            var c2 = repo.Lookup<Commit>("4a202b3");
            var b2 = c2["README"].Target as Blob;
            Assert.NotEqual(b1.ContentAsText(), b2.ContentAsText());
        }
    }
