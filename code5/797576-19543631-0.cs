    public abstract class SomeBase<T>
    {
        public List<T> BuildList(int v1, int v2)
        {
            var results = new List<T>();
    
            for (int i = v1; i < v2; i++)
            {
                results.Add(AddItem());
            }
            return results;
        }
        protected abstract T AddItem();
    }
    public class SubClass : SomeBase<BusinessThing>
    {
        protected override BusinessThing AddItem()
        {
            var entity = new BusinessThing();
            entity.Name1 = "1";
            entity.Name2 = "2";
            entity.Name3 = "3";
            return entity;
        }
    }
