    List<Item> lstItems = UnitOfWork.Items.GetAllAsync(); // repository pattern and Unit Of Work patterns
        
            foreach (Item item in lstItems)
            {
              try
              {
                 //do something with the item
              }
              catch(Exception ex)
              {
                 for(int i = 1; i <= 3; i++)
                 {
                     // do something with the item
                 }
                 // to continue external loop
                 continue;
              }
        
        }
