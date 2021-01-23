    private static object lockObject = new object();
    public static void AppendToFile(string fileName, string text){
       lock(lockObject){
          File.AppendAllText(fileName, text);
       }
    }
