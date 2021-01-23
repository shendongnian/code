    class JsonHelper
        {
            private const string INDENT_STRING = "    ";
            public static string FormatJson(string str)
            {
                var indent = 0;
                var quoted = false;
                var isEmptyArray = false;
                var sb = new StringBuilder();
                char ch = default(char);
                for (var i = 0; i < str.Length; i++)
                {
                    ch = str[i];
                    switch (ch)
                    {
                        case '{':
                            sb.Append(ch);
                            if (!quoted)
                            {
                                sb.AppendLine();
                                Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                            }
                            break;
                        case '[':
                            sb.Append(ch);
                            var stringRemainder = str.Substring(i);
                            var nextMatchingBracketIndex = stringRemainder.IndexOf(']');
                            isEmptyArray = nextMatchingBracketIndex != -1 ? stringRemainder.Substring(1, nextMatchingBracketIndex - 1).Trim().Length == 0 : false;
                            if (!quoted && !isEmptyArray)
                            {
                                sb.AppendLine();
                                Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                            }
                            break;
                        case '}':
                            if (!quoted)
                            {
                                sb.AppendLine();
                                Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                            }
                            sb.Append(ch);
                            break;
                        case ']':
                            if (!quoted && !isEmptyArray)
                            {
                                sb.AppendLine();
                                Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                            }
                            sb.Append(ch);
                            isEmptyArray = false;
                            break;
                        case '"':
                            sb.Append(ch);
                            bool escaped = false;
                            var index = i;
                            while (index > 0 && str[--index] == '\\')
                                escaped = !escaped;
                            if (!escaped)
                                quoted = !quoted;
                            break;
                        case ',':
                            sb.Append(ch);
                            if (!quoted)
                            {
                                sb.AppendLine();
                                Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                            }
                            break;
                        case ':':
                            sb.Append(ch);
                            if (!quoted)
                                sb.Append(" ");
                            break;
                        default:
                            if (!isEmptyArray)
                                sb.Append(ch);
                            break;
                    }
                }
                return sb.ToString();
            }
        }
