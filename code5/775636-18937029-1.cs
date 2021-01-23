    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace sorter
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new SortedList();
                var item = new SomeItem(1);
                list.Add(item.Value, item);
                item = new SomeItem(8);
                list.Add(item.Value, item);
                item = new SomeItem(2);
                list.Add(item.Value, item);
                item = new SomeItem(4);
                list.Add(item.Value, item);
    
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list.GetByIndex(i));
                }
    
                Console.ReadLine();
            }
        }
    
        public class SomeItem
        {
            public int Value;
    
            public SomeItem(int value)
            {
                Value = value;
            }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
