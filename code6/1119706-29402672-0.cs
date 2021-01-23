        class Pingdom {
            public static string PingMe(List<Config> configtypes)
            {
                bool status = true;
                List<Task> tasks2 = new List<Task>();
                foreach (Config config in configtypes)
                {
                    if (config.Type == ConfigTypes.Database)
                    {
                        tasks2.Add(Task.Factory.StartNew(() => { status = status && PingdomDB(config.ConnectionType); }, TaskCreationOptions.LongRunning));
                    }
                    else if (config.Type == ConfigTypes.API)
                    {
                        tasks2.Add(Task.Factory.StartNew(() => { status = status && PingdomAPI(config.ConnectionType); }, TaskCreationOptions.LongRunning));
                    }
                }
                if (status)
                    return "Ping";
                else
                    return "No Ping";
            }
        }
