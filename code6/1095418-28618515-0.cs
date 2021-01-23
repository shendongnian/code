        public void DoStuff()
        {
            List<Player> players = new List<Player>();
            foreach (var line in lines)
            {
                // Fill your players list
            }
            players.Sort(ComparePlayersDescending);
        }
        public int ComparePlayersDescending(Player p1, Player p2)
        {
            int scoreDiff = p2.Score - p1.Score;
            if (scoreDiff != 0)
                return scoreDiff;
            else
                return p2.Name.CompareTo(p1.Name);
        }
