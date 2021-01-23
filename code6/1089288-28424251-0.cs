    // TODO Refactor and optimize this function
            public IList<string> TokenizeExpression(string expr)
            {
                // TODO Add all your delimiters here
                var delimiters = new[] { '(', '+', ')', ',' };
                var buffer = string.Empty;
                var ret = new List<string>();
                expr = expr.Replace(" ", "");
                foreach (var c in expr)
                {
                    if (delimiters.Contains(c))
                    {
                        if (buffer.Length > 0) ret.Add(buffer);
                        ret.Add(c.ToString(CultureInfo.InvariantCulture));
                        buffer = string.Empty;
                    }
                    else
                    {
                        buffer += c;
                    }
                }
                return ret;
            }
