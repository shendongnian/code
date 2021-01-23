            CultureInfo c = new CultureInfo("en-us", true);
            c.DateTimeFormat.DateSeparator = ".";
            //c.DateTimeFormat.TimeSeparator= ".";//this will fail
            c.DateTimeFormat.TimeSeparator= ":";//this will work since TimeSeparator and DateSeparator  are different.
            Thread.CurrentThread.CurrentCulture = c;
            string s = DateTime.Now.ToString();
            DateTime dt;
            DateTime.TryParse(s, out dt);
            Console.WriteLine(s + "\n");
            Console.WriteLine(DateTime.Now + "\n");
            Console.WriteLine(dt.ToString() + "\n");
            DateTime.TryParse(s,
                              CultureInfo.CurrentCulture.DateTimeFormat,
                              DateTimeStyles.None,
                              out dt);
            Console.WriteLine(dt.ToString() + "\n");
