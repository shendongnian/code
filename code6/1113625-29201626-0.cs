    namespace TryOuts
    {
        using System;
        using System.Linq;
        using System.Collections.Generic;
        public class TestItem
        {
            public Int32 ID { get; set; }
            public Int32 Weight { get; set; }
        }
        public class TestItemPartition
        {
            public static IEnumerable<TestItemPartition> PartitionItems(IEnumerable<TestItem> items, Int32 weightPartitionLimit)
            {
                var weightSum = 0;
                var itemList = new List<TestItem>();
                var partitionNumber = 1;
                foreach (var item in items)
                {
                    if (weightSum + item.Weight > weightPartitionLimit && itemList.Count > 0)
                    {
                        // limit reached and at least one item is in the partition
                        yield return new TestItemPartition(partitionNumber++, weightSum, itemList);
                        // re-initialize for next partition.
                        weightSum = 0;
                        itemList = new List<TestItem>();
                    }
                    // limit not reached, or a first single item exceeds the partition limit.
                    // add item and increase weight sum.
                    weightSum += item.Weight;
                    itemList.Add(item);
                }
                // return partition for the last remaining items (if any).
                if (itemList.Count > 0)
                    yield return new TestItemPartition(partitionNumber, weightSum, itemList);
            }
            public int PartitionNumber { get; private set; }
            public Int32 TotalWeight { get; private set; }
            public int TotalItems 
            {
                get { return _items.Count(); }
            }
            public IEnumerable<TestItem> Items
            {
                get { return _items; }
            }
            private TestItemPartition(int number, Int32 totalWeight, List<TestItem> items)
            {
                PartitionNumber = number;
                TotalWeight = totalWeight;
                _items = items;
            }
            private List<TestItem> _items;
        }
        class Program
        {
            public static void Main(params string[] args)
            {
                var items = new[] {
                    new TestItem { ID = 1, Weight = 10  },
                    new TestItem { ID = 2, Weight = 120 },
                    new TestItem { ID = 3, Weight = 30  },
                    new TestItem { ID = 4, Weight = 70  },
                    new TestItem { ID = 5, Weight = 60  },
                    new TestItem { ID = 6, Weight = 10  }
                };
                foreach (var partition in TestItemPartition.PartitionItems(items, 100))
                    Console.WriteLine(
                        "#{0} - {1} items of total weight {2}.", 
                        partition.PartitionNumber, 
                        partition.TotalItems, 
                        partition.TotalWeight);
                Console.WriteLine("done");
                Console.ReadLine();
            }
        }
    }
