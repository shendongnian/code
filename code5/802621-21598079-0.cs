    public void <T,T2,T3> MYGenericFunction(IEnumerable<T> xmlList)
        where T: XMLBase<T3>
              T2: new, ControlBase<T3>
    {
        foreach (T xmlItem in xmlList)
        {
            T2 item = new T2();
            item.Name = toAdd.name;
            item.Val = toAdd.val;
            controlList.Add(T2);
        }
    }
    public class<T> ControlBase
    {
        public ControlBase();
        public string Name;
        public T Val;
    }
    public class<T> XMLBase
    {
        public string name;
        public T val;
    }
