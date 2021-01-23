    public static class ObjectChangedExtension
    {
        internal static ConditionalWeakTable<object, List<Action<BaseObject>>> observers
            = new ConditionalWeakTable<object, List<Action<BaseObject>>>();
        public static void RegisterObserver<T>(this T obj, ICustomObserver<T> observer)
            where T : BaseObject
        {
            Action<BaseObject> objChangedDelegate = v => observer.ObjectChanged((T)v);
            observers
                .GetOrCreateValue(obj)
                .Add(objChangedDelegate);
        }
        public static void FireObjectChanged(this BaseObject obj)
        {
            observers
                .GetOrCreateValue(obj)
                .ForEach(v => v(obj));
        }
    }
    #region code generator
    class DerivedObject1 : BaseObject
    {
    }
    class DerivedObject2 : BaseObject
    {
    }
    #endregion code generator
    #region application code
    class Observer : ICustomObserver<DerivedObject1>, ICustomObserver<DerivedObject2>
    {
        public void ObjectChanged(DerivedObject1 obj)
        {
            Console.WriteLine("DerivedObject1 Observer");
        }
        public void ObjectChanged(DerivedObject2 obj)
        {
            Console.WriteLine("DerivedObject2 Observer");
        }
    }
    class ObserverOfBase : ICustomObserver<BaseObject>
    {
        public void ObjectChanged(BaseObject obj)
        {
            Console.WriteLine("BaseObject Observer");
        }
    }
    #endregion application code
    #region sample
    class Program
    {
        internal static void Main(string[] args)
        {
            Observer observer = new Observer();
            List<BaseObject> objects = new List<BaseObject>();
            DerivedObject1 obj1 = new DerivedObject1();
            objects.Add(obj1);
            obj1.RegisterObserver(observer);
            DerivedObject2 obj2 = new DerivedObject2();
            objects.Add(obj2);
            obj2.RegisterObserver(observer);
            var baseObjectObserver = new ObserverOfBase();
            obj1.RegisterObserver(baseObjectObserver);
            obj2.RegisterObserver(baseObjectObserver);
            foreach (var bo in objects)
                bo.FireObjectChanged();
        }
    }
    #endregion sample
    
    public class BaseObject
    {
    }
    public interface ICustomObserver<T>
    {
        void ObjectChanged(T obj);
    }
