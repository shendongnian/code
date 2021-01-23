    public class MyJsonClass
        {
            public String Result { get; set; }
            public int Response_Code { get; set; }
            public String Message { get; set; }
            public Dictionary<String, Dictionary<String, JsonCategoryDescription>>
                      Collection { get; set; }
        }
        public class JsonCategoryDescription
        {
            public String Id_Category { get; set; }
            public String Name { get; set; }
            public String Date_Created { get; set; }
        }
