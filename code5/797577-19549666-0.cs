    public abstract class SomeBase
    {
        public List<T> BuildList<T>(int v1, int v2) where T: BusinessThing
        {
            var results = new List<T>();
    
            for (int i = v1; i < v2; i++)
            {
                results.Add(AddItem<T>());
            }
            return results;
        }
    
        protected abstract T AddItem<T>() where T:BusinessThing;
    }
    
    public class SubClass : SomeBase
    {
        protected override T AddItem<T>()
        {
            var entity = new BusinessThing();
            entity.Name1 = "1";
            entity.Name2 = "2";
            entity.Name3 = "3";
            return (T)entity;
        }
    }
