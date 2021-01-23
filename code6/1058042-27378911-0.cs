        public string MakeBold(string text, string[] splitwords)
        {
            var sb = new StringBuilder();
            var words = text.Split(" ");   
            sb.Append(@"{\rtf1\ansi");
            foreach (var word in words){
                foreach (var subword in word.Split(" "))
                {
                    if (splitwords.Contains(subword))
                    {
                        sb.Append(@"\b" + subword + @"\b0 ");
                    }
                    else
                    {
                        sb.Append(subword);
                        sb.Append(@" ");
                    }
                }
            }
            sb.Append(@"}");
            return sb.ToString();
        }
