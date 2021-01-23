      public static T CreateNewProject<T, V>(string token, string projectName) where V : IProject<T> 
                                                                               where T : new()
       {
            return (T)new object();
       }
