        public class MyItem : IComparable
        {
            public int? SortId { get; set; }
            public int CompareTo(object other)
            {
                if (SortId == null)
                    return -1;
                MyItem otherItem = other as MyItem;
                if (otherItem == null || otherItem.SortId == null)
                    return 1;
                return SortId.Value.CompareTo(otherItem.SortId.Value);
            }
        }
