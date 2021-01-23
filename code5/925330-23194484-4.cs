            string longstr = "thisisaverylongstringveryveryveryveryverythisisaverylongstringveryveryveryveryvery";
            IEnumerable<string> splitString = Regex.Split(longstr, "(.{16})").Where(s => s != String.Empty);
            foreach (string str in splitString)
            {
                System.Console.WriteLine(str);
            }
