    <TextBlock x:Name="txtBlock"/>
     string regexStr = @"<S>(?<Str>.*?)</S>|<B>(?<Bold>.*?)</B>";
            var str = "<S>foo bar </S><B>dong</B>";
            Regex regx = new Regex(regexStr);
            Match match = regx.Match(str);
            Run inline = null;
            while (match.Success)
            {
                if (!string.IsNullOrEmpty(match.Groups["Str"].Value))
                {
                    inline = new Run(match.Groups["Str"].Value);
                    txtBlock.Inlines.Add(inline);
                }
                else if (!string.IsNullOrEmpty(match.Groups["Bold"].Value))
                {
                    inline = new Run(match.Groups["Bold"].Value);
                    inline.FontWeight = FontWeights.Bold;
                    txtBlock.Inlines.Add(inline);
                }
                match = match.NextMatch();
            }
