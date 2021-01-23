    public class MusicPlayer
    {
        public class Player
        {
            public static void Song(String _path)[...]
            public static void List()[...]
        }
        private static Player m_player = new Player();
        public static Player Play
        {
            get { return m_player; }
        }
    }
