    void OuterLoop(list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            // some code that initializes inner
            if (InnerLoop(inner)) break;
        }
    }
    bool InnerLoop(inner)
    {
        for(int j = 0; j < inner.Count; j++)
        {
           // Some code that might change condition
           if (condition) return true;
        }
        return false;
    }
