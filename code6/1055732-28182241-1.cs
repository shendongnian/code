    public static bool PutFile(Session session, string bucket_name, string file_path, out string key)
        {
            if (!File.Exists(file_path))
            {
                throw new FileNotFoundException(file_path);
            }
            bool success = false;
            key = System.IO.Path.GetFileName(file_path);
            try
            {
                var soRepo = session.Factory.CreateStorageObjectRepository();
                string fullUrl = GenerateUrl(session, bucket_name, key);
                soRepo.Copy(file_path, fullUrl, false);
                success = true;
            }
            catch
            {
                success = false;
                key = string.Empty;
            }
            return success;
        }
