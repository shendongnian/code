    public class Bot
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string DisplayName { get; set; }
            public string Backpack { get; set; }
            public string ChatResponse { get; set; }
            public string logFile { get; set; }
            public string BotControlClass { get; set; }
            public int MaximumTradeTime { get; set; }
            public int MaximumActionGap { get; set; }
            public string DisplayNamePrefix { get; set; }
            public int TradePollingInterval { get; set; }
            public string LogLevel { get; set; }
            public string AutoStart { get; set; }
        }
        
        public class RootObject
        {
            public List<string> Admins { get; set; }
            public string ApiKey { get; set; }
            public string mainLog { get; set; }
            public string UseSeparateProcesses { get; set; }
            public string AutoStartAllBots { get; set; }
            public List<Bot> Bots { get; set; }
        }
        
        //Read file to string
        string json = File.ReadAllText("PATH TO settings.json");
        
        //Deserialize from file to object:
        JsonConvert.PopulateObject(json, RootObject);
        
        //Change Value
        RootObject.Bots[0].Password = "password";
        
        // serialize JSON directly to a file again
        using (StreamWriter file = File.CreateText(@"PATH TO settings.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
           serializer.Serialize(file, RootObject);
        }
