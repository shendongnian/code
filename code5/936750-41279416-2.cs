        private static object assemblyResolveLocker = new object();
        private static int assemblyCmpt = 0;
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (assemblyCmpt < Conf.DllPaths.Count)
            {
                try
                {
                    int c = 0;
                    foreach (string _path in Conf.DllPaths)
                    {
                        if (c < assemblyCmpt)
                        {
                            c++;
                        }
                        else
                        {
                            //Load my Assembly 
                            Assembly assem = Assembly.LoadFile(_path);
                            if (assem != null)
                                return assem;
                        }
                    }
                }
                catch { ;}
                return Assembly.GetExecutingAssembly();
            }
            else
            {
                return Assembly.GetExecutingAssembly();
            }
        }
