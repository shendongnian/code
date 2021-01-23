    string outputStr = "";
    
    for(int x = 0;x<xRefList.Count;x++)
    {
      for(int y = 0;y<WordList.Count;y++)
      {
         for(int z = 0;z<TitleList.Count;z++)
        {
            outputStr += xRefList[x] + " " + WordList[y] + " " + TitleList[z] + "\n";
        }
    
      }
    }
    
    MessageBox.Show(outputStr);
