    using System.Collections;
    public class InvItem
    {
    }
    public class InvItemList : IEnumerable
    {
        private List<InvItem> invItems;
        public InvItemList()
        {
            invItems = new List<InvItem>();
        }
        public IEnumerator GetEnumerator()
        {
            foreach (InvItem frmNewItem in invItems)
            {
                yield return frmNewItem;
            }
        }
    }
