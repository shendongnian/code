            public static void logResults(System.Reflection.MethodBase method, Results result, string message)
        {
            string date = DateTime.Now.ToString();
            int index = date.IndexOf(" ");
            string subString = date.Substring(0, index);
            string nwDate = Regex.Replace(subString, "/", "");
            logFileName = "WebsiteRegressionProduction_TestCycle." + nwDate;
            string currentLogFile = logFileLocation + @"\" + logFileName;
            if (!File.Exists(currentLogFile))
            {
                File.WriteAllText(currentLogFile,
                    "DATE-TIME\tACTION\tTEST CLASS\tTEST NAME\tTEST STATUS\tERROR MESSAGES\n\n", Encoding.ASCII);
            }
            var sb = new StringBuilder();
            sb.Append(String.Format("{0} : Test Executed: {1} : {2} : {3}\n\n", DateTime.Now.ToString(),
                method.ReflectedType.Name, method, message));
            sb.Append(DateTime.Now.ToString());
            using (var stream = File.AppendText(currentLogFile))
            {
                stream.Write(sb.ToString());
            }
        }
