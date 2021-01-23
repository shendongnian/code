            using (var sr = new StreamReader(FileUpload1.FileContent))
            {
                string line;
                int count = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    File.WriteAllText(Server.MapPath(string.Format("~/filename.txt{0}", count), line);
                    count ++;
                }
            }
