    public class InvItemList : IEnumerable<InvItem>, IEnumerable
    {
        // (...)
        IEnumerator<InvItem> IEnumerable<InvItem>.GetEnumerator()
        {
            return invItems.GetEnumerator();
        }
    }
