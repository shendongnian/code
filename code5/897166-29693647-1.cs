    @functions {
        string ToMarkdown(string str)
        {
            var lines = str.Split('\n');
            var whitespaceCount = 0;
            var i = 0; //from 2. Line
            var imax = lines.Count();
            while (++i < imax)
            {
                var line = lines[i];
                if (whitespaceCount != 0)
                {
                    lines[i] = line.Substring(whitespaceCount);
                    continue;
                }
                var trimmed = line.TrimStart();
                if (trimmed.Length == 0 || trimmed == line) continue;
                whitespaceCount = line.Length - trimmed.Length;
                i--;
            }
            str = string.Join("\n", lines);
            var md = new MarkdownDeep.Markdown {ExtraMode = true, SafeMode = false};
            return md.Transform(str);
        }
    }
