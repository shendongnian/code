    public class InvItemList : IEnumerable
    {
        private List<InvItem> invItems;
        public InvItemList()
        {
            invItems = new List<InvItem>();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return invItems.GetEnumerator();
        }
    }
