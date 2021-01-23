       using (var za = ZipFile.OpenRead(path))
       {
           foreach (var entry in sa.Entries)
           {
                    using (var r = new StreamReader(entry.Open()))
                    {
                        //your code here
                    }
           }
       }
