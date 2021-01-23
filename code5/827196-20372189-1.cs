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
            // First comb: treat each item as a standalone IOrder:
            var com = new Combination();
            foreach (var ele in intendedItems)
            {
                com.Orders.Add(ele);
            }
            potentialCombinations.Add(com);
            // check each possible pack (loaded from db) and find all possible combinations
            var possiblePacks = allPacksSetupFromDB.Where(m => m.Items.All(n => (intendedItems.Any(t => t.Unit.Id == n.Unit.Id && t.Quantity >= n.Quantity)))).ToArray();
            //ToDo: in the possible packages to use, find out all possible combinations
            //      This is the tricky part...
            // The one with lowest price is desired!
            return potentialCombinations.OrderBy(m => m.GetTotalPrice()).FirstOrDefault();
        }
    }
    }
