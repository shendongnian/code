    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
     
    /// <summary>
    /// Summary description for TestWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TestWebService : System.Web.Services.WebService {
     
        public TestWebService () {
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
     
        [WebMethod]
        public string GetPersonData(int id, Person objPerson) {
            return "You have submitted data with ID: " + id.ToString() + " Name: " + objPerson.Name + " and Email: " +  objPerson.Email;
        }
     
        [WebMethod]
        public Employee CreateEmployee(int id, Person objPerson) {
            Employee objEmployee = new Employee();
            objEmployee.ID = id;
            objEmployee.Name = objPerson.Name;
            objEmployee.Email = objPerson.Email;
            return objEmployee;
        }
         
        public class Person{
            public string Name {get;set;}
            public string Email {get;set;}
        }
     
        public class Employee : Person {
            public int ID { get; set; }
        }
    }
