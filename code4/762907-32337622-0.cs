    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Person> list = new List<Person>();
               Person oPerson = new Person();
                oPerson.Name = "Anshu";
                oPerson.Age = 23;
                oPerson.Address = " ballia";
                list.Add(oPerson);
                 oPerson = new Person();
                oPerson.Name = "Juhi";
                oPerson.Age = 23;
                oPerson.Address = "Delhi";
                list.Add(oPerson);
    
    
                oPerson = new Person();
                oPerson.Name = "Sandeep";
                oPerson.Age = 24;
                oPerson.Address = " Delhi";
                list.Add(oPerson);
    
                int index = 1;     // use for getting index basis value
    
                for (int i=0; i<list.Count;i++)
                {
                    Person values = list[i];
                    if (index == i)
                    {
                        Console.WriteLine(values.Name);
                        Console.WriteLine(values.Age);
                        Console.WriteLine(values.Address);
                        break;
                    }
                }
    
                Console.ReadKey();
    
            }
        }
    
        class Person
        {
            string _name;
            int _age;
            string _address;
    
            public String Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    this._name = value;
                }
    
            }
            public int Age
            {
                get
                {
                    return _age;
                }
                set
                {
                    this._age = value;
                }
            }
            public String Address
            {
                get
                {
                    return _address;
                }
                set
                {
                    this._address = value;
                }
    
            }
                 
        }
    }
