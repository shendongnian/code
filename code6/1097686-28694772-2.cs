    public static class ExtensionMethods
    {
        public static T CreateNewProject<T, V>(this V loader, string token, string projectName) where V : ICanLoadProject
        {
            loader.LoadProject(token, projectName);
            return default(T); //no clue what you want to return here
        }
    }
