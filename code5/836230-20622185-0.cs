            var regex = new Regex(@"[a-zA-Z0-9_]+", RegexOptions.Compiled);
            using (var reader = File.OpenText("in.txt"))
            using (var writer = File.CreateText("out.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var match = regex.Match(line);
                    if (match.Success)
                    {
                        // Alter the line however you wish here.
                    }
                    writer.WriteLine(line);
                }
                writer.Flush();
            }
