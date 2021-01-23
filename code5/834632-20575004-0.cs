     const Item ItemLookpupSentinel = null; 
     Item Serach(IEnumerable<Item> items)
     {
           var sequenceWithSentinel = 
              items.Concat(Enumerable.Repeat(ItemLookpupSentinel, 1));
           foreach(var item in  sequenceWithSentinel )
           {
                 if (item == ItemLookpupSentinel)
                    return null;
           }
     }
