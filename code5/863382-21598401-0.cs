    public interface IRemoveB
    {
        void RemoveB();
    }
    public class C1 : BaseClass1, IDeleteB
    {
        public int Id { get; set; }
        public virtual B B { get; set; }
        #region IDeleteB Member
        public void RemoveB()
        {
            this.B = null;
        }
        #endregion
    }
    public class B
    {
        public int Id { get; set; }
        public ICollection<IDeleteB>  list{ get; set; }
    }
    public class A
    {
        public int Id { get; set; }
        public virtual ICollection<B> bCollection { get; set; }
        public void prepareForDelete()
        {
            foreach (var item in bCollection)
            {
                foreach (var deref in item.list)
                {
                    deref.RemoveB();
                }
            }
        }
    }
