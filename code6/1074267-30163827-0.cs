            private static IReadOnlyList<Octokit.Repository> retrieveGitHubRepos()
        {
            Task<IReadOnlyList<Octokit.Repository>> getRepoList = null;
            string appname = System.AppDomain.CurrentDomain.FriendlyName;
            Octokit.GitHubClient client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue(ConnectionDetails.appName));
            client.Credentials = new Octokit.Credentials(ConnectionDetails.username, ConnectionDetails.password);
            Task.Run(() => getRepoList = client.Repository.GetAllForUser(ConnectionDetails.username)).Wait();
            return getRepoList.Result;
        }
