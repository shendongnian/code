    public String ReadFileData()
        {
            var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = Path.Combine(path.ToString(), "loginSystem.txt");
            String line;
            objData = new List<UsersData>();
            // Read the file and display it line by line.
            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                if (words.Length != 1)
                    objData.Add(new UsersData(words[0], words[1], words[2]));
            }
            file.Close();
            return String.Empty;
        }
