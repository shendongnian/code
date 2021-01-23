    public class myBindingList<myInt> : BindingList<myInt>
    {
            protected override void RemoveItem(int itemIndex)
            {
                myInt deletedItem = this.Items[itemIndex];
                if (BeforeRemove != null)
                {
                    BeforeRemove(deletedItem);
                }
                base.RemoveItem(itemIndex);
            }
            public delegate void myIntDelegate(myInt deletedItem);
            public event myIntDelegate BeforeRemove;
        }
