        public void Init()
        {
            var lines = File.ReadAllLines(@"C:\Config.txt");
            Array.ForEach(lines, ParseConfigLine);
        }
        private static void ParseConfigLine(string line)
        {
            var separatorIndex = line.IndexOf('=');
            if (separatorIndex < 1)
            {
                // you got malformed line without parameter name - raise an error
                throw new .... 
            }
            Action<string> setParameterAction = null;
            string parameterName = line.Substring(0, separatorIndex).Trim();
            switch (parameterName)
            {
                case "Server":
                    setParameterAction = v => ConfigurationDetails.Server = v;
                    break;
                case "username":
                    setParameterAction = v => ConfigurationDetails.UserName = v;
                    break;
                case "password":
                    setParameterAction = v => ConfigurationDetails.Password = v;
                    break;
                case "folder":
                    setParameterAction = v => ConfigurationDetails.Folder = v;
                    break;
                case "sqlserver":
                    setParameterAction = v => ConfigurationDetails.SqlServer = v;
                    break;
                default:
                    // unknown parameter - raise an error or ignore;
                    return;
            }
            string parameterValue = separatorIndex == line.Length - 1
                                        ? string.Empty
                                        : line.Substring(separatorIndex).Trim();
            setParameterAction(parameterValue);
        }
