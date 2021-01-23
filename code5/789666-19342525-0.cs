    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace IndexerSampleCode
    {
        class Program
        {
            static void Main(string[] args)
            {
                Indexer<Employee> indexer = new Indexer<Employee>();
                Employee e = new Employee();
                e.EmployeeID = 45;
                e.FirstName = "Tarik";
                e.LastName = "Hoshan";
                e.BirthDate = new DateTime(1965, 2, 18);
                indexer.add(e);
                var e2 = indexer.getByPropertyValue("EmployeeID", 45);
                Console.WriteLine(e2.FirstName);
                Console.ReadKey();
            }
        }
    
        class Indexer<T>
        {
            // Collection of dictionories that will be used to index properties of type int
            Dictionary<string, Dictionary<int, T>> intIndexes = new Dictionary<string, Dictionary<int, T>>();
    
            public Indexer() {
                System.Type indexerType = this.GetType().UnderlyingSystemType;
                System.Type elementType = indexerType.GetGenericArguments()[0];
                var members = elementType.GetProperties();
                // Loop through each property and create a Dictionary corresponding to it
                foreach (var member in members)
                {
                    if (member.PropertyType == typeof(int))
                    {
                        intIndexes.Add(member.Name, new Dictionary<int, T>());
                    }
                }
            }
    
            public T getByPropertyValue(string propertyName, int propertyValue)
            {
                Dictionary<int, T> index = intIndexes[propertyName];
                return index[propertyValue];
            }
    
            public void add(T o) {
                var type = o.GetType();
                var members = type.GetProperties();
                foreach (var member in members)
                {
                    if (member.PropertyType == typeof(int))
                    {
                        var propertyName = member.Name;
                        Dictionary<int, T> index = intIndexes[propertyName];
                        int value = (int) o.GetType().GetProperty(propertyName).GetValue(o, null);
                        index.Add(value, o);
                    }
                }
            }
        }
    
        // Sample test class
        class Employee
        {
            public DateTime BirthDate
            {
                set;
                get;
            }
    
            public string FirstName
            {
                set;
                get;
            }
    
            public string LastName
            {
                set;
                get;
            }
    
            public int EmployeeID {
                set;
                get;
            }
        }
    
    }
