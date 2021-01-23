    public class MyCustomRouteConstraint : IHttpRouteConstraint
    {
        private DbContext _context;
        private static object fileLockObject = new object();
        public MyCustomRouteConstraint ()
        {
            _context = new DbContext();
        }
        public bool Match(System.Net.Http.HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            var appDataPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/CustomNameRouteCache.txt");
            // lock variable so no 2 or more threads can try to create file at once
            lock (fileLockObject)
            {
                var list = new List<MyRouteModel>();
                // check if our cache file exists, if not, lets create it
                if (!File.Exists(appDataPath))
                {
                    using (var writer = new System.IO.StreamWriter(appDataPath))
                    {
                        // get all modules
                        var names = _context.CustomNames.ToList();
                        foreach (var item in names)
                        {
                            list.Add(Mapper.Map<MyRouteModel>(item));
                        }
                        // serialize the list to the file in json format
                        var json = JsonConvert.SerializeObject(list);
                        
                        // write to file
                        writer.Write(json);
                    };
                }
                else
                {
                    // open file and get json contents
                    using (var reader = new System.IO.StreamReader(appDataPath))
                    {
                        var json = reader.ReadToEnd();
                        list = JsonConvert.DeserializeObject<List<MyRouteModel>>(json);
                    }
                }
                // lets search our list and see if this value is in our modules
                foreach (var item in list)
                {
                    if (item.Name.Equals(values[parameterName].ToString()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
