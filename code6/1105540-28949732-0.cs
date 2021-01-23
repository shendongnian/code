        public static string EscapeSpecial(string s)
        {
            Contract.Requires(s != null);
            var sb = new StringBuilder();
            foreach(char c in s)
            {
                switch(c)
                {
                    case '[':
                    case ']':
                    case '%':
                    case '*':
                    {
                        sb.AppendFormat(CultureInfo.InvariantCulture, "[{0}]", c);
                        break;
                    }
                    case '\'':
                    {
                        sb.Append("''");
                        break;
                    }
                    default:
                    {
                        sb.Append(c);
                        break;
                    }
                }
            }
            return sb.ToString();
        }
