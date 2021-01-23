    public static class TestParser
    {
        static void Parse(string InputFile)
        {
            // Lots of code goes in here
        }
        static void Parse(List<string> InputFileList)
        {
            foreach(string path in InputFileList)
            {
                Parse(path);
            }
        }
    }
