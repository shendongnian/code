    public static class Config
    {
     public static readonly RelativeRoot;
     public static Config()
     {
    #if Debug
       RelativeRoot = "..\..\folder"
    #else
       RelativeRoot = "..\..\folder"
    #endif
     }
    }
