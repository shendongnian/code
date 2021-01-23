        string names = "*apple*mango*banana*sapota";
        List<string> test = new List<string>();
        string[] namesplit = names.Split('*'); 
        foreach(string namearry in namesplit)
        {
            test.Add(namearry);
            test.ToArray();
        }
