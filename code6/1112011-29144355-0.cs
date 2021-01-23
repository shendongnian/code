    var repoIssueRequest = new RepositoryIssueRequest
    {
        State = itemState,// Is ItemState.Open or ItemState.Closed
        //Labels = new[] { label1, label2}// Don't specify label names here
    };
    repoIssueRequest.Labels.Add("Label1");// Repeat for label 2 and so on or use .AddRange()
    var gitRepoIssues = (_gitHubclient.Issue.GetForRepository(string owner, string repo name, repoIssueRequest)).Result.ToList();
