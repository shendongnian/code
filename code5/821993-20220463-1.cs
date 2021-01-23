    public class MustBeValidWarehouse : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string warehouse = value.ToString();
                IInventService inventserv = DependencyResolver.Current.GetService<IInventService>();
                return (inventserv.GetWarehouses().Where(m => m.WarehouseId == warehouse).Count() != 0);
            }
            return false;
        }
    }
