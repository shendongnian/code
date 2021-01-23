    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Character
        {
            public string Name { get; set; }
        }
    
        class Micky : Character
        {
    
        }
    
        class Minnie : Character
        {
    
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var mickeys = new Dictionary<Guid, Character>();
                var searchKey = Guid.NewGuid  ();
                mickeys.Add(searchKey, new Micky { Name = "Micky A"});
                mickeys.Add(Guid.NewGuid(), new Micky { Name = "Micky B" });
    
                var minnies = new Dictionary<Guid, Character>();
                minnies.Add(Guid.NewGuid(), new Minnie { Name = "Minnie A" });
                minnies.Add(Guid.NewGuid(), new Minnie { Name = "Minnie B" });
    
    
                var searchedItem = mickeys.Union(minnies).Where(k => k.Key == searchKey).FirstOrDefault();
                Console.WriteLine(searchedItem.Value.Name);
    
            }
        }
    }
