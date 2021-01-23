    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ThreeTierSample.BLL;
    
    namespace ThreeTierSample.BLL
    {
    public class Student
    {
        public Student()
        {
        } 
        public void insert()
        {     
        }
      }
    }
    public class TestingClass
    {
    Student myStudent = new Student();  //  THIS IS OUTSIDE THE ThreeTierNamespace
                                        //  and will work                                      
    }
