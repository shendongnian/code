    public void DoNestedThings()
    {
        for(var A0 = 0; A0 < _max; A0 ++)
        {
            //...
            for(var i5 = 0; i5 < _max; i5++)
            {
                DoThing(new List<int>{i0, ..., i5});
            }
        }
    }
    
