    char toRemove = '$'
    // or init it with true if you assume that s='(asdsad)' 
    // need to be converted to 'asdsad'
    bool flag = false; 
    int i = 0;
    Stack<int> stack = new Stack<int>();
    
    while (i < s.Length)
    {
        if (s[i] == '(')
            stack.Push(i);
        else if (s[i] == ')')
        {
            int start = stack.Pop();
            if (flag)
                s[start] = s[i] = toRemove;
    
            flag = true;
        }
        else
            flag = false;
    
        i++;
    }
    
    s.Replace(toRemove.ToString(), "");
