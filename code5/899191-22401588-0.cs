    public static void Main(string[] args) 
    {
        Regex regex = new Regex("(([_ ]*[a-z]+)_ ?)+([_ ]*[a-z]+)");
        string str = "a_b_c_ _ _abc_ _ _ _abcd";
        Match match = regex.Match(str);
        // 2 - because of specific regex construction
        for (int i = 2; i < match.Groups.Count; i++) {
            foreach (Capture capture in match.Groups[i].Captures)
                Console.Write("[{0}]", capture.Value);
        }
        Console.ReadLine();
    }
