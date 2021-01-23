    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    namespace example
    {
    [Serializable]
    class Project
    {
        public int ID { get; set; }
        public string name { get; set; }
    }
    [Serializable]
    class Employee
    {
        public int Age{get;set;}
        public string name{get;set;}
        public List<Project> projects { get; set; }
    }
    public class mainClass
    {
        List<Employee> emplist = new List<Employee>();
        List<Project> prjlist = new List<Project>();
        public mainClass()
        {
            
            prjlist.Add(new Project{ID = 12, name = "Project A"});
            prjlist.Add(new Project{ID = 11, name = "Project B"});
            prjlist.Add(new Project{ID = 16, name = "Project C"});
            emplist.Add(new Employee{Age=15, name = "Tom",projects=prjlist});
            
            prjlist=null;
            prjlist.Add(new Project{ID = 17, name = "Project D"});
            prjlist.Add(new Project{ID = 18, name = "Project E"});
            prjlist.Add(new Project{ID = 10, name = "Project F"});
            emplist.Add(new Employee{Age=17, name = "Billy",projects=prjlist});
            
            prjlist=null;
            prjlist.Add(new Project{ID = 22, name = "Project X"});
            prjlist.Add(new Project{ID = 24, name = "Project Y"});
            prjlist.Add(new Project{ID = 19, name = "Project Z"});
            emplist.Add(new Employee{Age=25, name = "Sam",projects=prjlist});
        }
        
        public void showme()
        {
            int i=24;
            var result = from emp in emplist
                         select (emp.projects as List<Project>).Where(obj => obj.ID == i);
        }
    }
    }
