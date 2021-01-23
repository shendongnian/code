    splitLines.ForEach(l => 
        possibleNodes.Add(l
            .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList()
        )
    );
