    public class Query<E>: ObjectQuery, IProcessable<E>
    {
        public E this[int index]
        {
            get { throw new NotImplementedException(); }
        }
        public E First
        {
            get { throw new NotImplementedException(); }
        }
        public E Last
        {
            get { throw new NotImplementedException(); }
        }
        IEnumerable<E> IProcessable<E>.Processables
        {
            get { throw new NotImplementedException(); }
        }
    }
    interface IProcessable<E>
    {
        E this[int index] { get; }
        E First { get; }
        E Last { get; }
        IEnumerable<E> Processables { get; }
    }
