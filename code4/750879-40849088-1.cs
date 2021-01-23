            public void Log(string value, params object[] values)
        {
            // allow indenting
            if (!String.IsNullOrEmpty(value) && value.Length > 0 && value.Substring(0, 1) != "*")
            {
                value = "      " + value;
            }
            // write the log
            Console.WriteLine(String.Format(value, values));
        }
