    public static class ListBoxExtension
    {
        public static void SortBy<TElement>(this ListBox list,
                                  Func<TElement, object> fieldSelector)
        {
            var items = list.Items.OfType<TElement>()
                            .OrderBy(fieldSelector)
                            .Cast<object>().ToArray();
            list.BeginUpdate();
            list.Items.Clear();
            list.Items.AddRange(items);
            list.EndUpdate();
        }
        public static void SortByDescending(this ListBox list,
                                            Func<TElement, object> fieldSelector)
        {
            var items = list.Items.OfType<TElement>()
                            .OrderByDescending(fieldSelector)
                            .Cast<object>().ToArray();
            list.BeginUpdate();
            list.Items.Clear();
            list.Items.AddRange(items);
            list.EndUpdate();
        }           
    }
    //Usage
    listBox1.SortBy<object>(x=>x);
    //if your listBox1 has elements of the same type Item, use it like this:
    listBox1.SortBy<Item>(x=>x.SomeProperty);
