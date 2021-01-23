    Type[] types = new Type[] { typeof( Gold ) };
    
    int[] amounts = new int[] { 1 };
    
    List<Item> items = new List<Item>(World.Items.Values);
    foreach( Item i8 in items  )
    {
        if( i8 is Container ) 
        { 
            Container c1 = (Container)i8; 
            int _Index = BackpackList.IndexOf(c1.Serial);
            if ( _Index>=0 )
            {
                amounts[0] = GoldOriginal[_Index];
                int NewAmount = GoldAmounts[_Index];
    
                if (c1!=null) { c1.ConsumeTotal( types, amounts ); }
                if (c1!=null && NewAmount>0) { c1.AddItem(new Gold(NewAmount)); }
            }
        }
    }
