        void DiscoverDirs(string where, List<string> files)
        {
            try
            {
                files.AddRange(Directory.GetFiles(where));
                foreach (var dir in Directory.GetDirectories(where))
                {
                    DiscoverDirs(dir, files);
                }
            }
            catch
            {
                // no access fo this dir
            }
        }
