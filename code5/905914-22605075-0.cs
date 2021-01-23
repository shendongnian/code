       using (var sa = ZipFile.OpenRead("1.zip"))
       {
           foreach (var entry in sa.Entries)
           {
                    using (var r = new StreamReader(entry.Open()))
                    {
                        Console.WriteLine(r.ReadToEnd());
                    }
           }
       }
