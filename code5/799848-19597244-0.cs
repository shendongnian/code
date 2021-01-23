    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> list = new List<Item>();
                
                Item i = new Item()
                {
                    ID = 1,
                    Name = "Amit",
                    Description = "Test",
                     ItemGroup = new Group() { Name = "A" }
                };
                list.Add(i);
                i = new Item()
               {
                   ID = 2,
                   Name = "Amit1",
                   Description = "Test1",
                   ItemGroup = new Group() { Name = "A1" }
               };
                list.Add(i);
                i = new Item()
                {
                    ID = 3,
                    Name = "Amit11",
                    Description = "Test11",
                    ItemGroup = new Group() { Name = "A11" }
                };
                list.Add(i);
    
                i = new Item()
                {
                    ID = 4,
                    Name = "Amit111",
                    Description = "Test111",
                    ItemGroup = new Group() { Name = "A111" }
                };
                list.Add(i);
                i = new Item()
                {
                    ID = 9,
                    Name = "Amit4a",
                    Description = "Test4a",
                    ItemGroup = new Group() { Name = "A111" }
                };
                list.Add(i);
                i = new Item()
                {
                    ID = 5,
                    Name = "Amit5",
                    Description = "Test5",
                    ItemGroup = new Group() { Name = "A111" }
                };
                list.Add(i);
                i = new Item()
                {
                    ID = 6,
                    Name = "Amit6",
                    Description = "Test6",
                    ItemGroup = new Group() { Name = "A111" }
                };
                list.Add(i);
    
                var list1 = list.Where(p => p.ItemGroup.Name.Equals("A111"));
             //   Console.Write(list1.Count());
    
                foreach (var item in list1)
                {
                     Console.WriteLine(string.Format("ID: {0}  Name: {1}  Description:  {2}  Group: {3}",item.ID,item.Name,item.Description,item.ItemGroup.Name));
                }
                Console.Read();
            }
        }
    
        public class Group
        {
            public string Name { get; set; }
    
        }
        public class Item
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Group ItemGroup { get; set; }
    
        }
    }
