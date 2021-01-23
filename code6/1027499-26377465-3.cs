    string [] path_tab; //a tab of path, grouping all one day files
    
    foreach (string path in path_tab)
    {
      System.IO.StreamReader file = new System.IO.StreamReader(path, Encoding.Default);
      while (!file.EndOfStream)
      {
        string [] tab;
        string s = file.ReadLine();
        tab = s.split(',');
        if (dict.Contains(tab[0]) //ID
        {
          ((ItemXY)dict[tab[0]]).X += tab[1];
          ((ItemXY)dict[tab[0]]).Y += tab[2];
        }
        else
        {
            ItemXY newItem = new ItemXY();
            newItem.X = tab[1];
            newItem.Y = tab[2];
            dict.Add(tab[0], newItem);
        }
      }
      file.Close();
    }
