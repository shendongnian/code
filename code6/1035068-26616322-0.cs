     Parallel.Foreach (installations, ()=>
        {
            var path = string.Format(@"{0}/{1}", installation.FtpMap, "file");
            string fileToString = ftp.Download(path);
            var parser = new ParseService();
            parser.ParseStringFile(fileToString, installation);
            db.Entry(installation).State = EntityState.Modified;
            db.SaveChanges();
        }
