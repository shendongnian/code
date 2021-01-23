    private static void CreateNewFile()
           {
              string[] files = Directory.GetFiles(@"c:\test");
              int maxNumb = 0;
              foreach (var item in files)
              {
                  FileInfo file = new FileInfo(item);
                  maxNumb = Math.Max(maxNumb,     int.Parse(Path.GetFileNameWithoutExtension(file.FullName)));
              }
            File.Create(string.Format("{0}.txt", maxNumb++));
           }
