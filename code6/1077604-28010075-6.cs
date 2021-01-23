    static void Main(string[] args)
    {
        const int MAX_FILES = 10;
        const int BANS_PER_FILE = 10;
        int filesCounter = 0;
        int bansCounter = 0;
        var part = new List<int>();
        foreach (var ban in BANS)
        {
            part.Add(ban);
            if (++bansCounter >= BANS_PER_FILE)
            {
                string fileName = string.Format("{0}-{1}.txt", part[0], part[part.Count - 1]);
                Console.WriteLine("Filename '{0}'", fileName);
                foreach (var partBan in part)
                    Console.WriteLine(partBan);
                part.Clear();
                bansCounter = 0;
                if (++filesCounter >= MAX_FILES)
                    break;
            }
        }
    }
