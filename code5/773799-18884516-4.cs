        private string RemoveDuplicateParenthesis(string s)
        {
            char toRemove = '$';
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(i);
                else if (s[i] == ')')
                {
                    int start = stack.Pop();
                    var r = s.ToArray();
                    if ((start == 0 && i == (s.Length - 1)) || (s[start - 1] == '(' && s[i + 1] == ')'))
                        r[start] = r[i] = toRemove;
                }
            }
            var result = s.Replace(toRemove.ToString(), string.Empty);
            return result;
        }
