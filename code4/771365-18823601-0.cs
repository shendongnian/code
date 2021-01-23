    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    
    namespace reftest1
    {
        public enum status { CLOSED, OPEN }
    
        public class OR 
        {
            public string reference { get; set; }
            public string title { get; set; }
            public status status { get; set; }
            public int foo { get; set; }
    
        }
    
        //creates a dictionary by property of objects whereby that property is a valid value
        class Program
        {
            
            //create dictionary containing what constitues an invalid value here
            static Dictionary<string,Func<object,bool>> Validators = new Dictionary<string, Func<object,bool>>
                {
                    
                    {"reference", 
                        (r)=> { if (r ==null) return false;
                                  return !String.IsNullOrEmpty(r.ToString());}
                    },
                    {"title",
                        (t)=> { if (t ==null) return false;
                                  return !String.IsNullOrEmpty(t.ToString());}
                   }, 
                   {"status", (s) =>
                        {
                            if (s == null) return false;
                            return !String.IsNullOrEmpty(s.ToString());
                  }},
                 {"foo",
                     (f) =>{if (f == null) return false;
                                return !(Convert.ToInt32(f.ToString()) == 0);}
                        }
                };
    
            static void Main(string[] args)
            {
                var collection = new List<OR>();
                collection.Add(new OR() {reference = "a",foo=1,});
                collection.Add(new OR(){reference = "b", title = "test"});
                collection.Add(new OR(){reference = "c", title = "test", status = status.CLOSED});
    
                Type T = typeof (OR);
                var PropertyMetrics = new Dictionary<string, List<OR>>();
                foreach (var pi in GetProperties(T))
                {
                    PropertyMetrics.Add(pi.Name,new List<OR>());
                    foreach (var item in collection)
                    {
                        //execute validator if defined
                        if (Validators.ContainsKey(pi.Name))
                        {
                           //get actual property value and compare to valid value
                           var value = pi.GetValue(item, null);
                           //if the value is valid, record the object into the dictionary
                           if (Validators[pi.Name](value))
                           {
                               var lookup = PropertyMetrics[pi.Name];
                               lookup.Add(item);
                           }
                        }//end trygetvalue
                    }
                }//end foreach pi
                foreach (var metric in PropertyMetrics)
                {
                    Console.WriteLine("Property '{0}' is set in {1} objects in collection",metric.Key,metric.Value.Count);
                }
                Console.ReadLine();
            }
    
    
            private static List<PropertyInfo> GetProperties(Type T)
            {
                return T.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
            }
        }
    }
