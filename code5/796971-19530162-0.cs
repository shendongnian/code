        using (var fileStream = File.OpenRead("test.txt"))
        using (var userReader = new StreamReader(fileStream))
        {
            bool skipNextLine = false;
            while (!userReader.EndOfStream)
            {
                var line = userReader.ReadLine();
                if (!string.IsNullOrEmpty(line) && !skipNextLine)
                {
                    if (line.StartsWith("DeltaV"))
                    {
                        skipNextLine = true;
                    }
                    else if (!line.StartsWith("UserID"))
                    {
                        var array = line.Split(' ');
                        var user = new User();
                        user.Name = array[0];
                        Users.Add(user);
                    }
                }
                else
                {
                    skipNextLine = false;
                }
            }
        }
