    public class ItemService
    {
        public ItemEntity AddItem(ItemEntity e)
        {
            if (e != null)
            {
                using (var context = new MyContext())
                {
                    IDbSet<ItemEntity> entitySet = context.Set<ItemEntity>();
                    var entity = entitySet.Add(e);
                    context.SaveChanges();
                    return entity;
                }
            }
            return null;
        }
    }
