    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        static readonly List<EmployeeDetails> EmployeeList = new List<EmployeeDetails> { new EmployeeDetails { EmployeeId = 1, StoreId = 1 } };
        static readonly List<Stock> StockList = new List<Stock> { new Stock { ItemId = 1, Quantity = 50, StoreId = 1, UnitTypeId = 1 } };
        static readonly List<StoreInventoryDetails> InventoryList = new List<StoreInventoryDetails>
            {
                new StoreInventoryDetails { ItemId = 1, StoreId = 1, Quantity = 60},
                new StoreInventoryDetails { ItemId = 2, StoreId = 1, Quantity = 40}
            };
    }
    public class Stock
    {
        public int ItemId;
        public int StoreId;
        public int UnitTypeId;
        public int Quantity;
    }
    public class StoreInventoryDetails : Stock
    {
    }
    public class EmployeeDetails
    {
        public int EmployeeId;
        public int StoreId;
    }
