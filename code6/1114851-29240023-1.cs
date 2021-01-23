    [Test]
            public void Test2()
            {
                using (ZipFile zip = ZipFile.Read("D:/ArchiveTest.zip"))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        entry.Extract("D:/ArchiveTest");
                    }
    
                    zip.Dispose();
                }
    
                var updateList = Directory.GetFiles("D:/ArchiveTest").Where(x => x.Contains(".UPD"));
                foreach (string upd in updateList)
                {
                    string[] result = File.ReadAllLines(upd);
                    int index = Array.IndexOf(result, "[Info]");
    
                    //then I do stuff with index
                }
            }
