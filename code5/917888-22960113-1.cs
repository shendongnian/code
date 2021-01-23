    public class TenantType {
    
        private int value;
        private TenantType(int newValue)
        {
            value = newValue;
        }
        public override bool Equals(object obj)
        {
            return (obj is TenantType && (obj as TenantType).value == this.value;
        }
        public override int GetHashCode()
        {
            return value;
        }
        public static bool operator == (TenantType left, TenantType right)
        {
            return left.Equals(right);
        }
        public static bool operator != (TenantType left, TenantType right)
        {
            return !(left.Equals(right));
        }
        public static TenantType Admin = new TenantType(1);
        public static TenantType User = new TenantType(2);
        public static TenantType PublicUser = new TenantType(3);
    }
    public void DemoMethod(int pricePerTenant, TenantType tenantType)
    {
    }
    DemoMethod(4, TenantType.Admin);
