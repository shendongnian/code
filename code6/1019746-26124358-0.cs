    public class DerivedCollection : BaseCollection<DerivedClass>
    {
    protected override void InsertItem(int index, DerivedClass item)
        {
            base.InsertItem(index, item);
        }
    }
