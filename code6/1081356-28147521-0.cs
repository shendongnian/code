      public class MyComboItem : IEquatable<MyComboItem>
      {
        public int MyItemId { get; set; }
        public string MyItemName { get; set; }
        public bool Equals(MyComboItem other)
        {
            return MyItemId == other.MyItemId;
        }
      }
