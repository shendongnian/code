     public class LonglistSelectorPivot1<T> : List<T>
    {
        public delegate string GetKeyDelegate(T item);
        /// <summary>
        /// The Key of this group.
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="key">The key for this group.</param>
        public LonglistSelectorPivot1(string key)
        {
            Key = key;
        }
        /// <summary>
        /// Create a list of AlphaGroup<T> with keys set by a SortedLocaleGrouping.
        /// </summary>
        /// <param name="slg">The </param>
        /// <returns>Theitems source for a LongListSelector</returns>
        private static List<LonglistSelectorPivot1<T>> CreateGroups(SortedLocaleGrouping slg)
        {
            List<LonglistSelectorPivot1<T>> list = new List<LonglistSelectorPivot1<T>>();
            foreach (string key in slg.GroupDisplayNames)
            {
                list.Add(new LonglistSelectorPivot1<T>(key));
            }
            return list;
        }
        /// <summary>
        /// Create a list of AlphaGroup<T> with keys set by a SortedLocaleGrouping.
        /// </summary>
        /// <param name="items">The items to place in the groups.</param>
        /// <param name="ci">The CultureInfo to group and sort by.</param>
        /// <param name="getKey">A delegate to get the key from an item.</param>
        /// <param name="sort">Will sort the data if true.</param>
        /// <returns>An items source for a LongListSelector</returns>
        public static List<LonglistSelectorPivot1<T>> CreateGroups(IEnumerable<T> items, CultureInfo ci, GetKeyDelegate getKey, bool sort)
        {
            SortedLocaleGrouping slg = new SortedLocaleGrouping(ci);
            List<LonglistSelectorPivot1<T>> list = CreateGroups(slg);
            foreach (T item in items)
            {
                int index = 0;
                if (slg.SupportsPhonetics)
                {
                    //check if your database has yomi string for item
                    //if it does not, then do you want to generate Yomi or ask the user for this item.
                    //index = slg.GetGroupIndex(getKey(Yomiof(item)));
                }
                else
                {
                    index = slg.GetGroupIndex(getKey(item));
                }
                if (index >= 0 && index < list.Count)
                {
                    list[index].Add(item);
                }
            }
            if (sort)
            {
                foreach (LonglistSelectorPivot1<T> group in list)
                {
                    group.Sort((c0, c1) => { return ci.CompareInfo.Compare(getKey(c0), getKey(c1)); });
                }
            }
            return list;
        }
    }
