    public class myBindingList<myInt> : BindingList<myInt>
    {
            protected override void RemoveItem(int itemIndex)
            {
                //itemIndex = index of item which is going to be removed
                //get item from binding list at itemIndex position
                myInt deletedItem = this.Items[itemIndex];
                if (BeforeRemove != null)
                {
                    //raise event containing item which is going to be removed
                    BeforeRemove(deletedItem);
                }
                //remove item from list
                base.RemoveItem(itemIndex);
            }
            public delegate void myIntDelegate(myInt deletedItem);
            public event myIntDelegate BeforeRemove;
        }
