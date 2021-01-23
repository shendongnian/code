    public class Gift
    {
        public String GiftType { get; private set; }
        public String WrappingStyle { get; private set; }
        public Gift(String giftType, String wrappingStyle)
        {
            this.GiftType = giftType;
            this.WrappingStyle = wrappingStyle;
        }
    }
