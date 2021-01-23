    public class ProjectsRetriever
    {
        public string GetProjects()
        {
            //querying the result blocks the thread and wait for result.
            var projects = this.GetProjects(uri).Result;
            ... //require Thread1 to continue.
            ...
        }
    
        private async Task<IEnumerable<Project>> GetProjects(Uri uri)
        {
            //any thread can continue the method to return result because we use ConfigureAwait(false)
            return await this.projectSystem.GetProjects(uri, Constants.UserName).ConfigureAwait(false);
        }
    }
    public class ProjectSystem
    {
        public async Task<IEnumerable<Project>> GetProjects(Uri uri, string userName)
        {
            var projectClient = this.GetHttpClient<ProjectHttpClient>(uri);
            var projects = await projectClient.GetProjects();
            // code here is never hit because it requires Thread1 to continue its execution
            // but Thread1 is blocked in var projects = this.GetProjects(uri).Result;
            ...
    }
