            string longstr = "thisisaverylongstringveryveryveryveryverythisisaverylongstringveryveryveryveryvery";
            string[] splitString = Regex.Split(longstr, "(.{16})");
            foreach (string str in splitString)
            {
                System.Console.WriteLine(str);
            }
