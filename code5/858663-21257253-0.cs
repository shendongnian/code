    using System;
    using System.Collections.Generic;
    using System.Web;
    using WebMatrix.Data;
    public static class MyClass
    {
        public static IEnumerable<dynamic> GetData()
        {
            var db = Database.Open("razortest");
            var selectQueryString  = "SELECT * FROM tbl_stasjon ORDER BY nr";
            return = db.Query(selectQueryString);
        }
    }
