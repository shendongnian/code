        public class GameInfo {
            private Dictionary<int, PlayerInfo> playerDictionary;
            static void ProcessPlayerInfo(Dictionary<int, GameInfo> gameDictionary, int gameNr = 1)
            {
                foreach (var key in gameDictionary[gameNr].playerDictionary.Keys)
                {
                    var PlayerInfo = gameDictionary[gameNr].playerDictionary[key];
                    //do something
                }
            }
        }
