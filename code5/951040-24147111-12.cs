    namespace ProcessPassArguments
    {
        class Program
        {
            static void Main(string[] args)
            {
                string path = @"C:\Temp\Demo.exe";
                        string arguments = "one two three";
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = path,
                    Arguments = arguments
                };
                var process = Process.Start(startInfo);
            }
        }
    }
