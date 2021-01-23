     public void setVisible(int id, List<Data.myStruct> itemList)
     {
         Func<List<Data.myStruct>, int> getNextOrder = list =>
         {
             if (itemList.Any(item => item.order > 0))
                 return itemList.Max(item => item.order) - 1;
             return itemList.Count - 1;
         }; 
         for (int i = 0; i < itemList.Count; i++)
         {
             if (id == itemList[i].id && !itemList[i].visible)
             {
                 itemList[i] = new Data.myStruct(true, itemList[i].id, getNextOrder(itemList));
             }
         }
     }
