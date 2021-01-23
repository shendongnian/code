        public Dictionary<string, string> parseFasta(string multiFasta)
        {
            Dictionary<string, string> fastaDict = new Dictionary<string, string>();
            using (System.IO.StringReader multiFastaReader = new System.IO.StringReader(multiFasta))
            {
                // Skip any text before the first record (e.g. blank lines, comments)
                string line = multiFastaReader.ReadLine();
                while (true)
                {
                    if (line == "")
                    {
                        return fastaDict; // Premature end of file, or just empty?
                    }
                    if (line[0] == '>')
                    {
                        break;
                    }
                }
                while (true)
                {
                    if (line[0] != '>')
                    {
                        throw new Exception("Records in Fasta files should start with '>' character");
                    }
                    string title= line.Substring(1, line.Length-1).TrimEnd();
                    List<string> lines = new List<string>();
                    line = multiFastaReader.ReadLine();
                    while (true)
                    {
                        if (line == "")
                        {
                            break;
                        }
                        if (line == null)
                        {
                            break;
                        }
                        if (line[0] == '>')
                        {
                            break;
                        }
                        lines.Add(line.TrimEnd());
                        line = multiFastaReader.ReadLine();
                    }
                    // Remove trailing whitespace, and any internal spaces
                    string sequence = String.Join("", lines).Replace(" ", "").Replace("\r", "");
                    fastaDict.Add(title, sequence);
                    if (line == null)
                    {
                        return fastaDict;
                    }
                }
            }
         }
