    static void Main(string[] args)
    {
      string paths = "";
      foreach (string path in args)
      {
         paths += path + Environment.NewLine;
      }
      MessageBox.Show(path);
    }
