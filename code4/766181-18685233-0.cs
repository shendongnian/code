    private const int tabCount = 10;
    private string[] tabs = new string[tabCount];
    void SetTabs()
    {
      string tab = "";
      for(int x = 0; x<=tabCount - 1; x++)
      {
        tab += "\t";
        tabs[x] = tab;
      }
    }
