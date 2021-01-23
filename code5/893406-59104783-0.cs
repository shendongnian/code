                public void CreateDirectory()
                {
                string strArchiveFolder = (@"\\fullpath" + DateTime.Now.Year.ToString() + "\\" +
                                      DateTime.Now.Month.ToString());
                if (!Directory.Exists(strArchiveFolder))
                {
                Directory.CreateDirectory(strArchiveFolder);
                }
