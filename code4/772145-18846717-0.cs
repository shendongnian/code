        string str = "English (UK), French* , German and Polish  & Russian; Portugese and Italian";
        string[] results = str.Split(new string[] { ",", ";", "&", "*" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in results)
            if (!string.IsNullOrWhiteSpace(s))
                Console.WriteLine(s);
