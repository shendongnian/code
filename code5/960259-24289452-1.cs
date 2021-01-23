    class myList : List<Item> 
    {
        Item getItem(string name)
        {  
             foreach(var item in this)
             {
               if(item.Name==name) { return item; }
             }
    
             return null;
        }
    }
