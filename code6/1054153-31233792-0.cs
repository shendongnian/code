        public static async Task<string> CreateNewGame()
        {
            string newObjectId = null;
            ParseObject myGame = new ParseObject("Games");
            myGame["score"] = 223;
            myGame["playerName"] = "Michael";
            await myGame.SaveAsync().ContinueWith(
                  t =>
                  {
                      newObjectId = myGame.ObjectId;
                  });
            return newObjectId;
        }
