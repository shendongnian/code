    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    
    namespace NetCoreJsonNETDemo
    {
        internal class Person
        {
            [JsonProperty]
            internal string Name
            {
                get;
                set;
            }
    
            [JsonProperty]
            internal int? Age
            {
                get;
                set;
            }
        }
    
        internal class PersonContainer
        {
            public List<Person> Persons
            {
                get;
                set;
            }
        }
    
        class Program
        {
            static T RecoverPersonsWithJsonConvert<T>(string json)
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
    
            static T RecoverPersonsWithJObejct<T>(string json) where T : class
            {
                try
                {
                    return JObject.Parse(json).ToObject<T>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("JObject threw an Exception: " + ex.Message);
                    return null;
                }
            }
    
            static void Main(string[] args)
            {
                List<Person> persons = new List<Person>();
    
                persons.Add(new Person()
                {
                    Name = "Jack",
                    Age = 18
                });
    
                persons.Add(new Person()
                {
                    Name = "Sam",
                    Age = null
                });
    
                persons.Add(new Person()
                {
                    Name = "Bob",
                    Age = 36
                });
    
                string json = JsonConvert.SerializeObject(persons, new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
    
                List<Person> newPersons = RecoverPersonsWithJsonConvert<List<Person>>(json);
                newPersons = RecoverPersonsWithJObejct<List<Person>>(json);//JObject will throw an error, since the json text is an array.
    
                PersonContainer personContainer = new PersonContainer()
                {
                    Persons = persons
                };
    
                json = JsonConvert.SerializeObject(personContainer, new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
    
                newPersons = RecoverPersonsWithJObejct<PersonContainer>(json).Persons;
    
                newPersons = null;
                newPersons = RecoverPersonsWithJsonConvert<PersonContainer>(json).Persons;
    
                Console.WriteLine("Press any key to end...");
                Console.ReadKey();
            }
        }
    }
