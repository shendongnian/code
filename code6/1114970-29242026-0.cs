            var txt = "abc&4Red&fWhite";
            string pattern = "(&.)";
            var substrings = Regex.Split(txt, pattern).ToList();
            // Add color code Black for first item if no color code is specified
            if (substrings.First() != "&0")
                substrings.Insert(0, "&0");
            // Create 2 lists, one for texts and one for color codes
            var colorCodes = substrings.Where(i => i.StartsWith("&")).ToList();
            var textParts = substrings.Where(i => !i.StartsWith("&")).ToList();
            // Combine the 2 intermediary list into one final result
            var result = textParts.Select((item, index) => new { Text = item, ColorCode = colorCodes[index] }).ToList();
