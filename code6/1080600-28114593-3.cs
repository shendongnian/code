    private void makeJPG(string source, string background, string output)
    {
      using(var backgroundImg = Image.FromFile(background))
      using(var sourceImg = Image.FromFile(source))
      {
        float BGimg = backgroundImg.Height;
        float SubjectImg = sourceImg.Height;
        float ResultHeight = 100 * (BGimg / SubjectImg);
        int Height = Convert.ToInt32(ResultHeight);
        Process procJPG = new Process();
        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        procJPG.EnableRaisingEvents = false;
        procJPG.StartInfo.FileName = @"""C:\Program Files\ImageMagick-6.9.0-Q16\convert.exe""";
        procJPG.StartInfo.Arguments = string.Format(@"{1} ( {0} -resize {3}% ) -gravity South -composite {2}", source, background, output, Height);
        procJPG.StartInfo.UseShellExecute = false;
        procJPG.StartInfo.RedirectStandardOutput = true;
        procJPG.StartInfo.CreateNoWindow = true;
        procJPG.Start();
        procJPG.WaitForExit();
      }
    }
