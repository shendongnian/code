    if (TryOpenRegKey(Registry.ClassesRoot) ||
      TryOpenRegKey(Registry.LocalMachine, "SOFTWARE") ||
      TryOpenRegKey(Registry.CurrentUser, "SOFTWARE"))
    {
      ...
    }
    if (Is64BitOS)
    {
      if (TryOpenRegKey(Registry.ClassesRoot, "Wow6432Node") ||
        TryOpenRegKey(Registry.LocalMachine, "SOFTWARE\\Wow6432Node") ||
        TryOpenRegKey(Registry.CurrentUser, "SOFTWARE\\Wow6432Node"))
      {
        ...
      }
    }
