    class Program {
        private const string ConfigComment = ";";
        private const string ConfigDefine = "#define";
        private static readonly KeyValuePair<string, Action<string>> DefaultActionValuePair = new KeyValuePair<string, Action<string>>();
        private static readonly Dictionary<string, Action<string>> settingSection = new Dictionary<string, Action<string>>(){
                { "[SETTINGS]", UpdateSettingsConfiguration}
                { "[Section]", UpdateSectionConfiguration}
            };
        static void Main() {
            StreamReader reader = new StreamReader("input.txt");
            string currentLine = reader.ReadLine();
            Action<string> currentSection = null;
            do {
                if (currentLine.StartsWith(ConfigDefine)) { //Definitions are used different than the rest of the config file, handle them special.
                    string[] definition = currentLine.Substring(ConfigDefine.Length + 1).Split(' ');
                    AddDefinitions(definition[0], definition[1]);
                } else if (!currentLine.StartsWith(ConfigComment)) {
                    
                    var kvp =
                        settingSection.FirstOrDefault(
                            x => x.Key.StartsWith(currentLine, StringComparison.InvariantCultureIgnoreCase));
                    if (kvp.Equals(DefaultActionValuePair)) {
                        if (currentSection == null) {
                            //Invalid setting
                        } else {
                            currentSection(currentLine);
                        }
                    } else {
                        currentSection = kvp.Value;
                    }
                }
                currentLine = reader.ReadLine();
            } while (!reader.EndOfStream);
        }
        private static void AddDefinitions(string p1, string p2) {
            //Do stuff here
        }
        static void UpdateSettingsConfiguration(string setting) {
            //do stuff here
        }
        static void UpdateSectionConfiguration(string setting) {
            //do stuff here
        }
    }
