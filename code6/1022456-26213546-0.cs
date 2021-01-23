    public void AddItem(ItemDefine Item){
      bool exists = false;
      if(Backpack.Where(x => x.ItemName == Item.ItemName).ToArray().Length > 0)
          exists = true;
      switch(exists) {
          case true: {
                         // Item Exists
                         ItemDefine newItem = Backpack.Where(x => x.Itemname == Item.ItemName).FirstOrDefault();
                         // we double check to make sure it really exists.
                         If(newItem != null) {
                            newItem.ItemCount += 1;
                         }
                     } break;
          case false: {
                         // Item Does Not Exist
                         Backpack.add(Item);
                      } break;
          default: {
                       // Something went horribly wrong
                   } break;
      }
    }
