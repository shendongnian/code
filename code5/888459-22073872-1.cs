    if (a.Length == b.Length)
    {
        BitArray compareEq = a.Xor(b);
        bool same=true;
        for(int i=0; i<compareEq.Length; i++)
        {
            if(compareEq.Get(i))
            {
               same = false;
               break;
            }
        }
        if(same)
        {
           // same..
        }
        else
        {
           // different..
        }
    }
    else
    {
      // Different
    }
