    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    namespace ConsoleApplication7
    {
        class Item : List<object>
        {
            public Item()
            {
                this.Add(""); // for name;
                this.Add(0); // for value;
            }
            [JsonIgnore]
            public string Name { get { return this[0].ToString(); } set { this[0] = value; } }
            [JsonIgnore]
            public int Value { get { return (int)this[1]; } set { this[1] = value; } }
        }
        class Category
        {
            public string name { get; set; }
            public List<Item> data { get; set; }
            public Category()
            {
                this.data = new List<Item>();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var all = new Dictionary<string, Category>
                    {
                        {
                            "Animals", new Category()
                                {
                                    name = "Animals",
                                    data =
                                        new List<Item>()
                                            {
                                                new Item() {Name = "Cows", Value = 2},
                                                new Item() {Name = "Sheep", Value = 3}
                                            }
                                }
                            //include your other items here
                        }
                    };
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(all));
                Console.ReadLine();
            }
        }
    }
