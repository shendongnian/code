    public class Student {
       public long SID { get; set; }
       public string SNAME { get; set; }
       public long CITY { get; set; }
    }
    public class City {
        public long CID { get; set; }
        public string CNAME { get; set; }
    }
    ...
    public class HomeController : Controller {
        ...
        public JsonResult Students () {
            var students = new List<Student> {
                    new Student { SID = 1, SNAME = "ABC", CITY = 11 },
                    new Student { SID = 2, SNAME = "ABC", CITY = 12 },
                    new Student { SID = 3, SNAME = "ABC", CITY = 13 },
                    new Student { SID = 4, SNAME = "ABC", CITY = 13 },
                    new Student { SID = 5, SNAME = "ABC", CITY = 12 },
                    new Student { SID = 6, SNAME = "ABC", CITY = 11 }
                };
            var locations = new List<City> {
                    new City { CID = 11, CNAME = "Chennai"},
                    new City { CID = 12, CNAME = "Mumbai"},
                    new City { CID = 13, CNAME = "Delhi"}
                };
            // sort and concatinate location corresponds to jqGrid editoptions.value format
            var sortedLocations = locations.OrderBy(location => location.CNAME);
            var sbLocations = new StringBuilder();
            foreach (var sortedLocation in sortedLocations) {
                sbLocations.Append(sortedLocation.CID);
                sbLocations.Append(':');
                sbLocations.Append(sortedLocation.CNAME);
                sbLocations.Append(';');
            }
            if (sbLocations.Length > 0)
                sbLocations.Length -= 1; // remove last ';'
            return Json(new {
                       colModelOptions = new {
                           CITY = new {
                               formatter = "select",
                               edittype = "select",
                               editoptions = new {
                                   value = sbLocations.ToString()
                               },
                               stype = "select",
                               searchoptions = new {
                                   sopt = new[] { "eq", "ne" },
                                   value = ":Any;" + sbLocations
                               }
                           }
                       },
                       rows = students    
                   },
                   JsonRequestBehavior.AllowGet);
        }
    }
