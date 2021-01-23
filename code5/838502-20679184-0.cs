    public enum Status { Empty = 0, Normal = 1, Aged = 2, Dead = 3 }
    public class Item
    {
        public Status Status { get; }
    }
    public static int OrderedStatus(Item item)
    {
        switch (item.Status)
        {
            case Status.Normal: return 0;
            case Status.Aged: return 1;
            case Status.Empty: return 2;
            default : return 3; // case Status.Dead
        }
    }
