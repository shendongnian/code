    class Program
    {
        static void Main(string[] args)
        {
            var holder = new Holder<IObject>();
            holder.MyItem = new Object { List = new List<IObject>() };
            holder.ChangeItemList(new Object { List = new List<IObject>() });
        }
    }
    public class Object : IObject
    {
        public List<IObject> List { get; set; }
    }
    public interface IObject
    {
        List<IObject> List { get; set; }
    }
    public class Holder<T> where T : IObject
    {
        public T MyItem { get; set; }
        public void ChangeItemList(T item)
        {
            MyItem.List = item.List;
        }
    }
