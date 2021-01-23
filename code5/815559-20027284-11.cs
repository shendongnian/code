    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<GroceryItem> shoppingList = new List<GroceryItem>();
            List<string> groceries = new List<string>() { "veg, pot", "veg, tom", "meat, chicken", "meat, veal" };
            foreach (var line in groceries)
            {
                var parts = line.Split(',');
                shoppingList.Add(new GroceryItem(parts[0], parts[1]));
            }
            var sorted_list_by_ItemName =
                from item in shoppingList
                orderby item.ItemName
                group item by item.Category into groups
                select groups;
            
            foreach (var gr in sorted_list_by_ItemName)
            {
                Console.Out.WriteLine("[{0}] :", gr.Key);
                foreach (var it in gr)
                    Console.Out.WriteLine("    {0}", it);
            }
            Console.ReadKey();
        }
        public class GroceryItem
        {
            public GroceryItem(string category, string name)
            {
                Category = category;
                ItemName = name;
            }
            public string Category { get; set; }
            public string ItemName { get; set; }
            public override string ToString()
            {
                return Category + " , " + ItemName;
            }
        }
    }
