            Console.WriteLine(ConfigurationManager.OpenExeConfiguration(Path.GetFileName(Assembly.GetExecutingAssembly().CodeBase).ToString()).FilePath.ToString());
            string[] readText = File.ReadAllLines(ConfigurationManager.OpenExeConfiguration(Path.GetFileName(Assembly.GetExecutingAssembly().CodeBase).ToString()).FilePath.ToString());
            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }
