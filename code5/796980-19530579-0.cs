        // read user list text file
        var userReader = new StreamReader(File.OpenRead(UserListPath));
        var Area = "";
        while(!userReader.EndOfStream)
        {
            var line = userReader.ReadLine();
            if(line.Contains("DeltaV User List"))
            {
                Area = userReader.ReadLine();  // Area applies to group of users below.
                userReader.ReadLine(); // blank line
                userReader.ReadLine(); // blank line
                userReader.ReadLine(); // User ID header line
            }
            else
            {
                if (line.trim() != "") // Could be blank line before "DeltaV..." 
                {
                    var userid = line;
                    var newUser = new User();
                    newUser.Area = Area;
                    // I left the following lines in place so that you can test the results.
                    Console.WriteLine(userid);
                    var name = userid.Split(' ');
                    Console.WriteLine(name[0]);
                    newUser.UserId = name[0];
                    Users.Add(newUser);
                }
            }
        }
