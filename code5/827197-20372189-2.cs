    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace TestCSharp.Optimizer
    {
    public interface IUnit
    {
        int Id { get; set; }
        float UnitPrice { get; set; }
    }
    public interface IOrder
    {
        int Quantity { get; set; }
        float GetTotalPrice();
    }
    public interface IOrder<T> : IOrder where T : IUnit
    {
        T Unit { get; }
    }
    public abstract class AbstractUnit : IUnit
    {
        public int Id { get; set; }
        public float UnitPrice { get; set; }
    }
    public class Item : AbstractUnit
    {
        public string Name { get; set; }
    }
    public class Package : AbstractUnit
    {
        private List<Order<Item>> _items = new List<Order<Item>>();
        // Items here are required by the package - number of items is specified by the quantity.
        public IEnumerable<Order<Item>> Items
        {
            get { return this._items; }
        }
    }
    public class Order<T> : IOrder<T> where T : IUnit
    {
        T _unit;
        public Order(T unit)
        {
            _unit = unit;
        }
        public T Unit { get { return _unit; } }
        public int Quantity { get; set; }
        public float GetTotalPrice()
        {
            return _unit.UnitPrice * Quantity;
        }
    }
    public class Combination
    {
        private List<IOrder> _orders = new List<IOrder>();
        private Combination()
        {
            // Private constructor
        }
        public List<IOrder> Orders { get { return _orders; } }
        /// <summary>
        /// Get the total number of items ordered (combine package as well)
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, int> GetItemIdAndQuantity()
        {
            var output = new Dictionary<int, int>();
            foreach (var order in this._orders)
            {
                if (order is Order<Item>)
                {
                    var orderedItem = (Order<Item>)order;
                    if (!output.Keys.Contains(orderedItem.Unit.Id))
                    {
                        output.Add(orderedItem.Unit.Id, 0);
                    }
                    output[orderedItem.Unit.Id] = output[orderedItem.Unit.Id] + ((Order<Item>)order).Quantity;
                }
                else
                {
                    var orderedPackage = (Order<Package>)order;
                    foreach (var item in orderedPackage.Unit.Items)
                    {
                        var itemId = item.Unit.Id;
                        if (!output.Keys.Contains(itemId))
                        {
                            output.Add(itemId, 0);
                        }
                        output[itemId] = output[itemId] + item.Quantity * orderedPackage.Quantity;
                    }
                }
            }
            return output;
        }
        public float GetTotalPrice()
        {
            if (_orders.Any())
            {
                return _orders.Select(m => m.GetTotalPrice()).Sum();
            }
            return 0;
        }
        public static Combination GetBestCombination(IEnumerable<Order<Item>> intendedItems, IEnumerable<Package> allPacksSetupFromDB)
        {
            var potentialCombinations = new List<Combination>();
            // check each possible pack (loaded from db) and find all possible combinations
            // Step 1: for each package, if it could be used potentially, collect it into a list
            var possibleRanges = new List<PackageUseRange>();
            foreach (var p in allPacksSetupFromDB)
            {
                // for each required item in a package, intended items have to fulfill at least one occurrence (with given quantity)
                if (p.Items.All(n => (intendedItems.Any(t => t.Unit.Id == n.Unit.Id && t.Quantity >= n.Quantity))))
                {
                    var rng = new PackageUseRange(p);
                    rng.Min = 0;
                    // Find the possible max occurrence of the package
                    var matchedOrders = intendedItems.Where(x => p.Items.Any(m => m.Unit.Id == x.Unit.Id));
                    rng.Max = matchedOrders.Select(m => m.Quantity / p.Items.First(t => t.Unit.Id == m.Unit.Id).Quantity).Min();
                    possibleRanges.Add(rng);
                }
            }
            // By now we should have something like: 
            // package 1: min 0, max 2
            // package 2: min 0, max 1
            // package 3: min 0, max 3
            // ...
            // Step 2: find all possible combinations:            
            if (possibleRanges.Any())
            {
                // define a collection to collect combinations 
                // also define a method to clear unwanted combinations. 
                var combinations = new List<Combination>();
                Action invalidOrderRemover = delegate()
                {
                    for (int j = combinations.Count - 1; j >= 0; j++)
                    {
                        var theCom = combinations[j];
                        var orderedQuantities = theCom.GetItemIdAndQuantity();
                        foreach (var itemId in orderedQuantities.Keys)
                        {
                            var intended = intendedItems.First(m => m.Unit.Id == itemId).Quantity;
                            if (orderedQuantities[itemId] > intended)
                            {
                                combinations.Remove(theCom);
                                break;
                            }
                        }
                    }
                };
                
                // For first package, let's create orders with different quantities
                var firstPack = possibleRanges[0];
                for (int i = firstPack.Min; i <= firstPack.Max; i++)
                {
                    var order = new Order<Package>(firstPack.Package);
                    order.Quantity = i;
                    var com = new Combination();
                    com.Orders.Add(order);
                    combinations.Add(com);
                }                
                // From second onwards:  
                //      1. we expand the orders created earlier and collect current pack (with different quantity)
                //      2. we also take out those impossible combinations so far (total quantity exceeds wanted)
                for (int i = 1; i < possibleRanges.Count - 1; i++)
                {
                    invalidOrderRemover.Invoke(); // to avoid the list/array unreasonably large
                    // expand orders based on current pack's range:
                    var currPack = possibleRanges[i];
                    var expanded = new List<Combination>();
                    foreach (var oldCom in combinations)
                    {
                        for (int j = currPack.Min; j <= currPack.Max; j++) 
                        {
                            // Clone from previous and pick up new ones from existing package. 
                            var newCom = new Combination();
                            newCom.Orders.AddRange(oldCom.Orders);
                            var newOrder = new Order<Package>(currPack.Package);
                            newOrder.Quantity = j;
                            newCom.Orders.Add(newOrder);
                        }
                    }
                    // Clear old and add back the expanded:
                    combinations.Clear();
                    combinations.AddRange(expanded);
                }
                // Clear unwanted again:
                invalidOrderRemover.Invoke();
                // Add back balanced items:
                foreach (var cb in combinations)
                {
                    var fulfilled = cb.GetItemIdAndQuantity();
                    foreach (var item in intendedItems)
                    {
                        if (!fulfilled.Keys.Contains(item.Unit.Id))
                        {
                            // no such item in any package
                            // thus just add new Item based order
                            var newOrder = new Order<Item>(item.Unit);
                            newOrder.Quantity = item.Quantity;
                            cb.Orders.Add(newOrder);
                        }
                        else
                        {
                            // check balance:
                            if (fulfilled[item.Unit.Id] < item.Quantity)
                            {
                                var newOrder = new Order<Item>(item.Unit);
                                newOrder.Quantity = item.Quantity - fulfilled[item.Unit.Id];
                                cb.Orders.Add(newOrder);
                            }
                        }
                    }
                }
                // Add to the final combination collection
                potentialCombinations.AddRange(combinations);
            }
            // Step 3: If there is no package used at all, treat each item as a standalone IOrder:
            if (!potentialCombinations.Any())
            {
                var com = new Combination();
                foreach (var ele in intendedItems)
                {
                    com.Orders.Add(ele);
                }
                potentialCombinations.Add(com);
            }
            // The one with lowest price is desired!
            return potentialCombinations.OrderBy(m => m.GetTotalPrice()).FirstOrDefault();
        }
        private class PackageUseRange
        {
            public PackageUseRange(Package p)
            {
                this.Package = p;
                this.Min = 0;
                this.Max = 0;
            }
            public Package Package { get; private set; }
            public int Min { get; set; }
            public int Max { get; set; }
        }
    }
    }
