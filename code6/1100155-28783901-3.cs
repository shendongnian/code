    Console.Write(Items.Apples.Name());
    Console.Write(Items.Apples.Section());
    Console.Write(Items.Apples.Units());
    public void doStuff(Items item)
    {
         if (item.Section() == SectionType.Produce)
         {
            // do something
         }
    
         if (item.Units() == UnitTypes.Pound)
         {
             //do something else
         }
    }
