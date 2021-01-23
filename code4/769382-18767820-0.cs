    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            Person mike = new Person { Name = "Mike" };
            Person jack = new Person { Name = "Jack" };
            jack.Parent = mike;
            List<Person> people = new List<Person>();
            people.Add(mike);
            people.Add(jack);
    
            var cloneOfEverything = Serializer.DeepClone(people);
    
            var newMike = cloneOfEverything.Single(x => x.Name == "Mike");
            var newJack = cloneOfEverything.Single(x => x.Name == "Jack");
            Console.WriteLine(jack.Parent.Name); // writes Miks as expected
    
            bool areSamePersonObject = ReferenceEquals(newMike, newJack.Parent);
            // False ^^^
    
            bool areSameStringInstance = ReferenceEquals(
                newMike.Name, newJack.Parent.Name);
            // True ^^^
        }
    }
    [ProtoContract]
    class Person
    {
        [ProtoMember(1)]
        public string Name;
        [ProtoMember(2)]
        public Person Parent;
    }
