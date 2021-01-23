    List<string> values = new List<string>();
            values.Add("A");
            values.Add("C");
            values.Add("D");
            values.Add("E");
            values.Add("F");
            values.Add("G");
            values.Add("A");
            values.ForEach(a => { if (a == "A") { a = "new value"; } });
