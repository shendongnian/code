            var input = "<a href=\"foo\"></a> &nbsp; &nbsp; Some text...";
            int startIndex = input.LastIndexOf(">") + 1;
            int endIndex = startIndex;
            while (true)
            {
                if(char.IsLetterOrDigit(input[endIndex]))
                    break;
                if (input[endIndex] == '&')
                    endIndex += 5;
                else
                    endIndex++;
            }
            var sb = new StringBuilder();
            sb.Append(input.Substring(0, startIndex));
            sb.Append(input.Substring(startIndex, endIndex - startIndex).Replace(" ", "&nbsp;"));
            sb.Append(input.Substring(endIndex));
