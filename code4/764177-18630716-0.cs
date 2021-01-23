    public class Product
    {
        public Guid Id { get; set; }
        public List<ProductPermission> Permissions { get; set; }
        public void AddPermission(ProductPermission permission)
        {
            if(Permissions == null)
            {
                Permissions = new List<ProductPermission>();
            }
            Permissions.Add(permission);
        }
    }
