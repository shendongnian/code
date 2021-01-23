    public async Task<bool> DoesDatabaseExist()
        {
            bool dbexists = true;
            try
            {
                var files = Package.Current.InstalledLocation.GetFilesAsync();
                var retvalues = (from f in await files
                                 where f.Name == "FixedCamerasOk.sqlite"
                                 select f);
                int count = retvalues.Count();
               
                if (count > 0)
                    return dbexists;
                else
                    return false;
                            }
            catch (Exception)
            {
                dbexists = false;
            }            
            return dbexists;
        }
