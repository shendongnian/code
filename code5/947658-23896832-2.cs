    public Server FindServerByID(List<Server> list, string id)
    {
         for (int i = 0; i < list.Count; i++)
         {
             var item = list[i];
             if (item.ServerID == id)
             {
                  return item;
             }
         }
         return null;
    }
