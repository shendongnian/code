    static void Main(string[] args)
    {
        string[] strs = new string[]
        {
            "a@site.ru:bvxb02lt;mu:10",
            "b@site.ru:abc;ewfewf;tu:10"
        };
    
        foreach (var str in strs)
        {
            // 0: login 1: password & domain 2: limits
            var pieces = str.Split(new char[] { ':' });
    
            string login = pieces[0];
            string limits = pieces[2];
    
            // Split password & domain (only at the first `;`)
            var innerPieces = pieces[1].Split(new char[] { ';' }, 2);
    
            string password = innerPieces[0];
            string domain = innerPieces[1];
        }
    }
