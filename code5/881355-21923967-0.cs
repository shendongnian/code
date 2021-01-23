    public class MySuperControl : Control
    {
        private List<MySmallControl> _smallControls;
    
        public MySuperControl()
        {
            Controls = new CControlCollection(this);
            //_smallControls = ... //creating of small controls
            ((Control)this).Controls.AddRange(_smallControls);
        }
    
        class MySmallControl : UserControl
        {
            //contains button and checkbox
        }
        //Wrapper for the Control.Controls property of the MySuperControl
        public new CControlCollection Controls { get; private set; }
        public class CControlCollection : ICollection<Control>
        {
            private Collection<Control> items;
            private MySuperControl parent;
            public CControlCollection(MySuperControl parent)
            {
                items = new Collection<Control>();
                this.parent = parent;
            }
            public int Count
            {
                get { return items.Count; }
            }
            public bool IsReadOnly
            {
                get { return false; }
            }
            public void Add(Control item)
            {
                items.Add(item);
                ((Control)parent).Controls.Add(item);
            }
            public void AddRange(Control[] itemsArray)
            {
                foreach (Control item in itemsArray)
                {
                    items.Add(item);
                    ((Control)parent).Controls.Add(item);
                }
            }
            public void Clear()
            {
                foreach (Control c in items)
                {
                    ((Control)parent).Controls.Remove(c);
                }
                items.Clear();
            }
            public bool Contains(Control item)
            {
                return items.Contains(item);
            }
            public void CopyTo(Control[] array, int arrayIndex)
            {
                items.CopyTo(array, arrayIndex);
            }
            public bool Remove(Control item)
            {
                ((Control)parent).Controls.Remove(item);
                return items.Remove(item);
            }
            public IEnumerator<Control> GetEnumerator()
            {
                return items.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return items.GetEnumerator();
            }
        }
    }
