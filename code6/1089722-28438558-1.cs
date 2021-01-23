    private void DoNestedThings(int depth, Stack<int> indexes)
    {
        if(depth == 0)
        {
            DoThing(indexes);
            return;
        }
        for(var i = 0; i < _max; i++)
        {
            indexes.Push(i);
            DoNestedThings(depth-1, indexes);
            indexes.Pop();
        }
    }
    public void DoNestedThings()
    {
        DoNestedThings(5, new Stack<int>());
    }
    
