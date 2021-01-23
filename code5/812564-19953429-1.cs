    public class Parent
    {
        public string Name { get; set; }
        // Note that this is a custom private collection class
        private readonly ChildCollection _children;
        public ICollection<Child> Children
        {
            get { return _children; }
        }
              
        private class ChildCollection : 
            System.Collections.ObjectModel.Collection<Child>
        {
            private readonly Parent _parent;
            public ChildCollection(Parent parent)
            {
                _parent = parent;
            }
            protected override void InsertItem(int index, Child item)
            {
                // remove from previous parent
                if (item.Parent != null)
                    item.Parent.Children.Remove(item);
                base.InsertItem(index, item);
                
                // assign the new parent
                item.Parent = _parent;
            }
            protected override void RemoveItem(int index)
            {
                // this item no longer has a parent
                var item = this[index];
                base.RemoveItem(index);
                item.Parent = null;
            }
            protected override void SetItem(int index, Child item)
            {
                // remove from previous parent
                if (item.Parent != null)
                    item.Parent.Children.Remove(item);
                base.SetItem(index, item);
                // assign the new parent
                item.Parent = _parent;
            }
            protected override void ClearItems()
            {
                foreach (var i in this)
                    i.Parent = null;
                base.ClearItems();
            }
        }
        public Parent()
        {
            _children = new ChildCollection(this);
        }
    }
