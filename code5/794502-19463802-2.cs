    [Fact]
    public void CanRetrieveTwoVersionsOfTheSameBlob_ReduxEdition()
    {
        using (var repo = new Repository(BareTestRepoPath))
        {
            var b1 = repo.Lookup<Blob>("8496071:README");
            var b2 = repo.Lookup<Blob>("4a202b3:README");
    
            Assert.NotEqual(b1.ContentAsText(), b2.ContentAsText());
        }
    }
