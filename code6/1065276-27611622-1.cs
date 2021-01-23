            // This is your ComboBox.
            var comboBox = new ComboBox();
            // load your file
            var fileLines = new[]
            {
                "DIRT: 3;",
                "STONE: 6;"
            };
            // This regular expression will match anything that
            // begins with some letters, then has a colon followed
            // by optional whitespace ending in a number and a semicolon.
            var regex = new Regex(@"(\w+):\s*([0-9])+;", RegexOptions.Compiled);
            // This does the same as the foreach loop did, but it puts the results into a dictionary.
            var dictionary = fileLines.Select(line => regex.Match(line).Groups)
                .ToDictionary(tokens => tokens[1].Value, tokens => int.Parse(tokens[2].Value));
            // When you enumerate a dictionary, you get the entries as KeyValuePair objects.
            foreach (var kvp in dictionary) comboBox.Items.Add(kvp);
            // DisplayMember and ValueMember need to be set to
            // the names of usable properties on the item type.
            // KeyValue pair has "Key" and "Value" properties.
            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
