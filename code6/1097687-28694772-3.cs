    public static class ExtensionMethods
    {
        public static T CreateNewProject<T>(this ICanLoadProject loader, string token, string projectName)
        {
            loader.LoadProject(token, projectName);
            return default(T); //no clue what you want to return here
        }
    }
