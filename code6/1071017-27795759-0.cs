    public void ProcessModules(List<Module> modules)
    {
        List<Module> myModules = new List<Module>(modules);//Take a copy of the list
        int index = myModules.Count - 1;
        while (myModules.Count > 0)
        {
            if (index < 0)
            {
                index = myModules.Count - 1;
            }
            Module module = myModules[index];
            if (!Monitor.TryEnter(module.Locker))
            {
                index--;
                continue;
            }
            try
            {
                //Do processing module
            }
            finally
            {
                Monitor.Exit(module.Locker);
                myModules.RemoveAt(index);
                index--;
            }
        }
    }
