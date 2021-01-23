    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic; //have to install this via nuget or download it
    
    public class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
    
    
    class Program {
        static void Main(string[] args) {
            var peeps = new List<Person>{
                new Person(){ FirstName="Tim", LastName="Smith", DOB = DateTime.Now},
                new Person(){ FirstName="Tim", LastName="Smith", DOB = DateTime.Now.AddDays(1)},
                new Person(){ FirstName="Mike", LastName="Smith", DOB = DateTime.Now.AddDays(2)},
                new Person(){ FirstName="Frank", LastName="Jones", DOB = DateTime.Now.AddDays(3)},
            };
    
            var eq = peeps.GroupBy("new (LastName, FirstName)", "it").Select("new(it.Key as Key, it as People)"); ;
            foreach (dynamic el in eq) {
                Console.WriteLine(el.Key);
                foreach (var person in el.People as IEnumerable<Person>) {
                    Console.WriteLine(person.LastName + " " + person.DOB);
                }
            }            
        }
    }
