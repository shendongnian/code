    private string RemoveDoubleParenthesis(string initialString)
    {
        char[] s = new char[initialString.Length];
        char toRemove = '$';
        Stack<int> stack = new Stack<int>();
        
        for (int i = 0; i < s.Length; i++)
        {
            s[i] = initialString[i];
            if (s[i] == '(')
                stack.Push(i);
            else if (s[i] == ')')
            {
                int start = stack.Pop();
                if ((start == 0 && i == (s.Length - 1)) 
                 || (s[start-1] == '(' && s[i+1] == ')'))
                {
                    s[start] = s[i] = toRemove;
                }
            }
        }
        
        return new string((from c in s where c != toRemove select c).ToArray());
    }
