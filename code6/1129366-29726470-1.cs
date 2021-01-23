    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                vouchers ovouchers = new vouchers();
                ovouchers.INV_InventoryItems = new List<inventory>(){
                   new inventory{
                       ItemID = 123, ItemPrice = 1
                   },
                   new inventory{
                       ItemID = 123, ItemPrice = 2
                   },
                   new inventory{
                       ItemID = 123, ItemPrice = 3
                   },
                   new inventory{
                       ItemID = 124, ItemPrice = 1
                   },
                   new inventory{
                       ItemID = 124, ItemPrice = 1
                   },
                };
                var inventoryByID = ovouchers.INV_InventoryItems.AsEnumerable()
                    .GroupBy(x => x.ItemID, y => y.ItemPrice)
                    .Select(x => new { ID = x.Key, total = x.Sum() });
                string boxID = "123";
                double itemID = inventoryByID.Where(x => x.ID == int.Parse(boxID)).Select(y => y.total).FirstOrDefault();
            }
        }
        public class vouchers
        {
            public List<inventory> INV_InventoryItems { get; set; }
        }
        public class inventory
        {
            public int ItemID { get; set; }
            public double ItemPrice { get; set; }
        }
    }
    ​
    ​
