    public class ClonableList<T> : List<T>, ICloneable
        where T : ICloneable
    {
        public object Clone()
        {
            ClonableList<T> newList = new ClonableList<T>();
            foreach (T item in this)
            {
                newList.Add((T)item.Clone());
            }
            return newList;
        }
    }
