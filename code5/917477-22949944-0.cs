            const string tString = "\\\\Apple-butter27\\AliceFakePlace\\SomeDay\\Grand100\\Some File Name Stuff\\Yes these are fake words\\One more for fun2000343\\myText.txt";
            const string tRegexPattern = @"(\\\\)?((?<Folder>[a-zA-Z0-9- ]+)(\\))";
            const RegexOptions tRegexOptions = RegexOptions.Compiled;
            Regex tRegex = new Regex(tRegexPattern, tRegexOptions);
            Console.WriteLine(tString);
            if (tRegex.Matches(tString).Count == 7)
            {
                foreach (Match iMatch in tRegex.Matches(tString))
                {
                    if (iMatch.Success && iMatch.Groups["Folder"].Length > 0)
                    {
                        Console.WriteLine(iMatch.Groups["Folder"].Value);
                    }
                }
            }
            else
                throw new Exception("String did not have a path of depth 7");
