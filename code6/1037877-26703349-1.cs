    public class DisplayEntities<T, K>
        where T : EntityDataBase
        where K : EntityBase
    {
        public T entityData { get; set; }
        public K entity { get; set; }
        public void DisplayData()
        {
            entity = (K)entityData.GetEntityData();
            
            Console.WriteLine(entity.DisplayData());
        }
    }
