    public static bool InstallService(string fullFileName)
        {
            try
            {
                using (var ai = new AssemblyInstaller(fullFileName, null))
                {
                    ai.Install(null);
                    ai.Commit(null);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
