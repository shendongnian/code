        static void Main(string[] args)
        {
            string input = "[ (Nucleosome, Stable, 21, 25), (Transcription_Factor, REB1, 48, 6), (Nucleosome, Stable, 64, 25), (Transcription_Factor, TBP, 90, 5) ]";
            read_time_step(input);
            Console.Read();
        }
        public static void read_time_step(string input)
        {
            string pattern = @"\((.)*?\)";
            MatchCollection mc = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in mc)
            {
                string v = match.Value.Trim('(', ')');
                string[] IntermediateList = v.Split(',');
                Console.WriteLine("Found type: '{0}', Found subtype: '{1}', Found position: '{2}', Found length '{3}'", 
                IntermediateList[0].Trim(), IntermediateList[1].Trim(), IntermediateList[2].Trim(), IntermediateList[3].Trim());
            }
        }
