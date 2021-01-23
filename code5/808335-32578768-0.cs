    void Main() {
            string path = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Local Settings\TEST");
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo files in dir.GetFiles())
            {
                files.Delete();
            }
            foreach (DirectoryInfo dirs in dir.GetDirectories())
            {
                dirs.Delete(true);
            }
        }
