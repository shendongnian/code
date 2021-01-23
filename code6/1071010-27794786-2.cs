    internal class MyCollection<T> : Collection<T> where T : Foo
    {
        protected override void InsertItem(int index, T item)
        {
            item.Bar += Bar_Handler;
            base.InsertItem(index, item);
        }
    }
