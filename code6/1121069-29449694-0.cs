    public class DerivedClass : BaseClass, ISortable<DerivedClass>
    {
        public new ISortableCollection<DerivedClass> ParentCollection
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
