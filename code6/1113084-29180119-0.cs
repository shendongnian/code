       using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
    
    namespace async
    {
    
        public class students
        {
            public string Name { get; set; }
            public string College { get; set; }
        }
    
    
        public class Class1
        {
           
            public List<students> filter(string keyvalue, IList<students> stud)
            {
              return   stud.OrderBy( (x => keyvalue == "name" ? x.Name :x.College  ) ).ToList();
            }  
    
    
            public static void Main()
            {
    
                IList<students> students = new List<students>()
                {
                   new students (){Name="xxx",College="bbb"},
                   new students (){Name="bbb",College="aaa"},
                    new students (){Name="aaa",College="xxx"}
                };         
    
                Class1 c = new Class1();
    
                var foo= c.filter("name", students);
                
            }
        }
    }
