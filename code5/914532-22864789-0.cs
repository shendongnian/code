    using (var parser = new TextFieldParser(filename))
    {
        parser.SetDelimiters(",");
        while (!parser.EndOfData)
        {
            var p = parser.ReadFields();
            players.Add(new Player(p[0], p[1], int.Parse(p[2]), int.Parse(p[3]), int.Parse(p[4])));
	    }
    }
