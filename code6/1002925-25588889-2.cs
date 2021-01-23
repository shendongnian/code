    public class ProjectsRetriever
    {
        public string GetProjects()
        {
            ...
            var projects = this.GetProjects(uri).Result;
            ...//requires Thread1 to continue
            ...
        }
    
        private async Task<IEnumerable<Project>> GetProjects(Uri uri)
        {
            //requires Thread1 to continue
            return await this.projectSystem.GetProjects(uri, Constants.UserName);
        }
    }
    
    public class ProjectSystem
    {
        public async Task<IEnumerable<Project>> GetProjects(Uri uri, string userName)
        {
            var projectClient = this.GetHttpClient<ProjectHttpClient>(uri);
            var projects = await projectClient.GetProjects().ConfigureAwait(false);
            // no deadlock, resumes in a new thread. After this function returns, Thread1 could continue to run
    }
