    public static IEnumerable<T> GetObjectsOrderedAsDisplayed<T>(this ObjectListView olv) where T : class
    {
        IList<OLVListItem> list = new List<OLVListItem>();
        for (int i = 0; i < olv.GetItemCount(); i++)
        {
            list.Add(olv.GetNthItemInDisplayOrder(i));
        }
        return list.Select(x => x.RowObject as T).Where(x => x != null);
    }
