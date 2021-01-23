    public void EndOperation()
    {
        // Pop object from stack.
        if (stack.Count != 0)
        {
            using (var context = stack.Pop())
            {
                ... do various stuff with 'context' ...
            }
        }
    }
