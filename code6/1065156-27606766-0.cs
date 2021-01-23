    public static string GetBasePath(bool isAspNetAppDomain)
    {
            return isAspNetAppDomain 
                ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin") 
                : AppDomain.CurrentDomain.BaseDirectory;
    }
