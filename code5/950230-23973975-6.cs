    public static class LevelManager
    {
        private static string lastLevel;
        public static void setLastLevel(string level)
        {
            lastLevel = level;
        }
        
        public static string getLastLevel()
        {
            return lastLevel;
        }
    }
