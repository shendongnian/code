    Dictionary<int, KeyValuePair<string, string>> GetFileProps(string filename)
    {
      Shell shl = new ShellClass();
      Folder fldr = shl.NameSpace(Path.GetDirectoryName(filename));
      FolderItem itm = fldr.ParseName(Path.GetFileName(filename));
      Dictionary<int, KeyValuePair<string, string>> fileProps = new Dictionary<int, KeyValuePair<string, string>>();
      for (int i = 0; i < 100; i++)
      {
        string propValue = fldr.GetDetailsOf(itm, i);
        if (propValue != "")
        {
          fileProps.Add(i, new KeyValuePair<string, string>(fldr.GetDetailsOf(null, i), propValue));
        }
      }
      return fileProps;
    }
