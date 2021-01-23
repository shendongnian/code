            System.IO.File.Delete(rqfile);
            while (true) {
                try
                {
                    System.IO.File.Copy(e.FullPath, rqfile);
                    break;
                }
                catch { }
            }
            System.IO.File.Delete(e.FullPath);
