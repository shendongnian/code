    public class SubClass : SomeBase
    {
        protected override T AddItem<T>()
        {
            var entity = new ConcreteBusinessThing();
            entity.Name1 = "1";
            entity.Name2 = "2";
            entity.Name3 = "3";
            return (T)(object)entity; // ugly cast but is always ok
        }
    }
