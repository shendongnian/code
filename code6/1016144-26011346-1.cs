    public class Program
    {
        public static void Main(string[] args)
        {
            const int employeeId = 1;
            var storeId = EmployeeList.Single(t => t.EmployeeId == employeeId).StoreId;
            CanAddProduct(1, storeId); // false
            CanAddProduct(2, storeId); // true
        }
        static bool CanAddProduct(int itemId, int storeId)
        {
            var inventory = InventoryList.FirstOrDefault(t => t.ItemId == itemId && t.StoreId == storeId);
            if (inventory == null)
            {
                throw new ApplicationException("No such product in inventory");
            }
            var stock = StockList.Where(st => st.ItemId == itemId &&
                st.Quantity < inventory.Quantity && st.StoreId == storeId);
            if (stock.Any())
            {
                Console.WriteLine("You can't add ItemId={0}. You have The minimum stock", itemId);
                return false;
            }
            Console.WriteLine("You can add ItemId={0}", itemId);
            return true;
        }
    }
