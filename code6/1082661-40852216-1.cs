    int nTries = 0;
    do
    {
      string szText = System.IO.File.ReadAllText(path);
      if (szText.Length != 0)
      {
        return szText;
      }
      else
      {
        System.Threading.Thread.Sleep(1000);
      }
    } while (nTries++ < 10);
    return "";
