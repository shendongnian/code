    public static void setVisible(int id, List<Data.myStruct> itemList)
    {
        int previousOrder = int.MinValue;
        for (int i = 0; i < itemList.Count; i++)
        {
            if (id == itemList[i].id)
            {
                previousOrder = itemList[i].order;
                itemList[i] = new Data.myStruct(true, itemList[i].id, itemList.Count - 1);
            }
        }
        if (previousOrder == int.MinValue)
            return;
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].id != id && itemList[i].order > 0 && itemList[i].order >= previousOrder)
            {
                var order = itemList[i].Order - 1;
                itemList[i] = new Data.myStruct(true, itemList[i].id, order);
            }
        }
    }
