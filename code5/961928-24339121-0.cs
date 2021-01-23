        private static void Main(string[] args)
        {
            var data =
                "[{\"PID\": 3,\"FirstName\": \"parveen\",\"LastName\": \"a\",\"Gender\": \"male\"},{\"PID\": 8,\"FirstName\": \"ramarao\",\"LastName\": \"M\",\"Gender\": \"male\"}]";
            var dattable = toDataTable(data);
            var list = toList(data);
        }
        class User
        {
            public int PID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
        }
        private static List<User> toList(string json)
        {
           return Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json);
        } 
        private static DataTable toDataTable(string json)
        {
            var result = new DataTable();
            var jArray = JArray.Parse(json);
            //Initialize the columns, If you know the row type, replace this   
            foreach (var row in jArray)
            {
                foreach (var jToken in row)
                {
                    var jproperty = jToken as JProperty;
                    if (jproperty == null) continue;
                    if (result.Columns[jproperty.Name] == null)
                        result.Columns.Add(jproperty.Name,typeof(string));
                }
            }
            foreach (var row in jArray)
            {
                var datarow = result.NewRow();
                foreach (var jToken in row)
                {
                    var jProperty = jToken as JProperty;
                    if (jProperty == null) continue;
                    datarow[jProperty.Name] = jProperty.Value.ToString();
                }
                result.Rows.Add(datarow);
            }
            return result;
        }
