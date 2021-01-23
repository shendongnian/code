            using (var fileStream = File.OpenRead(UserListPath))
            using (var userReader = new StreamReader(fileStream))
            {
                string currentArea = string.Empty;
                string currentToken = string.Empty;
                while (!userReader.EndOfStream)
                {
                    var line = userReader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        var tokenFound = Tokens.FirstOrDefault(x => line.StartsWith(x));
                        if (string.IsNullOrEmpty(tokenFound))
                        {
                            switch (currentToken)
                            {
                                case AreaToken:
                                    currentArea = line.Trim();
                                    break;
                                case UserToken:
                                    var array = line.Split(' ');
                                    if (array.Length > 0)
                                    {
                                        Users.Add(new User()
                                        { 
                                            Name = array[0],
                                            Area = currentArea
                                        });
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            currentToken = tokenFound;
                        }
                    }
                }
            }
