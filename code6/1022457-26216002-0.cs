    public void AddItem(ItemDefine Item){
    		bool finished = false;
    		for (int bSlot = 0; bSlot < Backpack.Count; bSlot++) {
    			//if slot is empty, add item
    			if(Backpack[bSlot].ITEM.ItemIcon == null){
    				if(!finished){
    					Backpack[bSlot].ITEM = Item;
    					finished = true;
    				}
    			}else if (Backpack[bSlot].ITEM.ItemName == Item.ItemName) {
    				if (!finished) {
    					Backpack[bSlot].ITEM.ItemCount += 1;
    					finished = true;
    				}
    			}
    		}
    	}
