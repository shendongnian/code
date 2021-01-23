            string inputText =
                @"Designator	MAX PN	Footprint	Center-X(mm)	Center-Y(mm)	Layer	Fitted	Orentation	Designator	level
                hi	hi	hi	hi	hi	hi	remove	remove	remove	remove ";
            string outputText = String.Empty;
            // Reading line by line to simulate a text file
            foreach (var line in inputText.Split('\n'))
            {
                // Ignore first line (headers)
                if (!line.Contains("Designator"))
                {
                    // Split by \t (tab) and remove blank space
                    var tokens = line.Split('\t').Select(x => x.Trim());
                    // Take first 6 tokens (0 to 5)
                    var newTokens = tokens.Take(6);
                    // Join the new tokens into a new string (you would want to write this to your file...)
                    outputText += String.Join("", newTokens) + Environment.NewLine;
                }
            }
