         public class City
        {
            public int Id { get; set; }
            public string CityName{ get; set; }
        }
        static List<City> _City = InitCitys();
        private static List<City> Citys()
        {
            var returnList = new List<City>();
            returnList.Add(new City{ Id = 0, CityName= "Sinop" });
            returnList.Add(new City{ Id = 1, CityName= "Ayancık" });
            returnList.Add(new City{ Id = 2, CityName= "İstanbul" });
            return returnList;
        }
        // GET api/values
        public JsonResult<City> Get(int Id)
        {
            var cityJsonResult = _City.Where(x => x.Id == Id).SingleOrDefault();
            return Json(cityJsonResult);
        }
