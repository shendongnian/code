    void AddItem(int id)
    {
        var item = ItemDatabase.Items.FirstOrDefault(x=> x.ID == id);
        if(item!=null){
            playerItems.Add(new Item(){ ID = item.ID, Name = item.Name, etc... })
        }
    }
