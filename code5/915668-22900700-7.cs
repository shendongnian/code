    public class Game
    {
        .....
        public string GameData 
        {
            // Only a getter, thus readonly
            get
            {
                return this.ToString();
            }
        }
    }
